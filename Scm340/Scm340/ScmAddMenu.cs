using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scm340
{
    public partial class ScmAddMenu : Form
    {
        string itemCode, itemName;
        int itemQty, itemMin, itemMax;
        float itemPrice;
        DateTime itemDate = DateTime.Today;

        //Null data is invalid, therefore all fields are initially invalid
        bool invalidPrice = true, invalidQty = true, invalidMin = true, invalidMax = true;
        bool missingCode = true, missingName = true;

        public ScmAddMenu()
        {
            InitializeComponent();
        }

        private void DateField_ValueChanged(object sender, EventArgs e)
        {
            //DateTime Pickers force user to select from calendar
            //Therfore parsing the field is always safe
            DateTimePicker temp_dtpicker = (DateTimePicker)sender;
            itemDate = DateTime.Parse(temp_dtpicker.Text);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Button temp_button = (Button)sender;

            switch (temp_button.Name)
            {
                case "BackButton":
                    Program.MainForm.Show();

                    //Tells garbage collector this temporary form object will not be used again
                    this.Dispose();
                    break;

                case "AddButton":
                    //Display validation message and return if invalid data exists
                    if (missingCode) { MessageBox.Show("Please enter a product code"); return; };
                    if (missingName) { MessageBox.Show("Please enter a product name"); return; };
                    if (invalidPrice) { MessageBox.Show("Please enter a valid price"); return; };
                    if (invalidQty) { MessageBox.Show("Please enter a valid quantity"); return; };
                    if (invalidMin) { MessageBox.Show("Please enter a valid minimum quantity"); return; };
                    if (invalidMax) { MessageBox.Show("Please enter a valid maximum quantity"); return; };

                    ScmStockItem temp_item = new ScmStockItem(itemCode, itemName, itemPrice, itemDate, itemQty, itemMin, itemMax);
                    ScmEventMediator.OnStockAdded(temp_item, new EventArgs());
                    break;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox temp_field = (TextBox)sender;

            //Whenever a field value is changed, update its variable
            switch (temp_field.Name)
            {   
                case "CodeField":
                    itemCode = temp_field.Text;
                    //Track if required fields are empty
                    missingCode = temp_field.Text.Length == 0;
                    break;
                case "NameField":
                    itemName = temp_field.Text;
                    missingName = temp_field.Text.Length == 0;
                    break;
                case "PriceField":
                    //We can't guarantee a safe data parse, we track if invalid data exists
                    invalidPrice = !float.TryParse(temp_field.Text, out itemPrice);
                    break;
                case "QtyField":
                    invalidQty = !int.TryParse(temp_field.Text, out itemQty);
                    break;
                case "MinField":
                    invalidMin = !int.TryParse(temp_field.Text, out itemMin);
                    break;
                case "MaxField":
                    invalidMax = !int.TryParse(temp_field.Text, out itemMax);
                    break;
            }
        }
    }
}
