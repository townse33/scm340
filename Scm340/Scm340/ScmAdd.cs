using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Scm340
{
    public partial class ScmAdd : Form
    /* This partial class acts as an interface to program the GUI behaviour without directly
     * coding the GUI appearance which is rather verbose and was generated using the
     * Windows Form Designer */
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        string itemCode, itemName;
        int itemQty, itemMin, itemMax;
        float itemPrice;
        DateTime itemDate = DateTime.Today;

        //Null data is invalid, therefore all fields are initially invalid
        bool invalidPrice = true, invalidQty = true, invalidMin = true, invalidMax = true;
        bool missingCode = true, missingName = true;

        ScmEvent StockAdded;

        public ScmAdd()
        {
            StockAdded += ScmEventMediator.OnStockAdded;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get event sender as button via cast
            Button temp_button = (Button) sender;
            Form temp_form;
            //Behaviour is determined by button name
            switch (temp_button.Name)
            {
                case "AddButton":
                    //Switch to Add Stock GUI by creating a new GUI and hiding this one
                    temp_form = new ScmAdd();
                    temp_form.Show();
                    this.Hide();
                    break;

                case "ViewButton":
                    temp_form = new ScmView();
                    temp_form.Show();
                    this.Hide();
                    break;

                case "ReportButton":
                    temp_form = new ScmReport();
                    temp_form.Show();
                    this.Hide();
                    break;

            }

        }

        private void DateField_ValueChanged(object sender, EventArgs e)
        {
            //DateTime Pickers force user to select from calendar
            //Therfore parsing the field is always safe
            DateTimePicker temp_dtpicker = (DateTimePicker)sender;
            itemDate = DateTime.Parse(temp_dtpicker.Text);
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ScmAdd_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            panel5.BackColor = Color.FromArgb(52, 159, 219);
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (missingCode) { MessageBox.Show("Please enter a product code"); return; };
            if (missingName) { MessageBox.Show("Please enter a product name"); return; };
            if (invalidPrice) { MessageBox.Show("Please enter a valid price"); return; };
            if (invalidQty) { MessageBox.Show("Please enter a valid quantity"); return; };
            if (invalidMin) { MessageBox.Show("Please enter a valid minimum quantity"); return; };
            if (invalidMax) { MessageBox.Show("Please enter a valid maximum quantity"); return; };

            ScmStockItem temp_item = new ScmStockItem(itemCode, itemName, itemPrice, itemDate, itemQty, itemMin, itemMax);
            StockAdded(temp_item, new EventArgs());
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Form temp_form = new ScmView();
            temp_form.Show();
            this.Hide();
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            panel6.BackColor = Color.FromArgb(52, 159, 219);
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel6.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            Form temp_form = new ScmReport();
            temp_form.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void scm_Click(object sender, EventArgs e)
        {
            Program.MainForm.Show();
            Dispose();
        }

        private void ScmAdd_Load_1(object sender, EventArgs e)
        {

        }

        private void textChanged(object sender, EventArgs e)
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
