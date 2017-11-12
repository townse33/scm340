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
    public partial class ScmViewMenu : Form
    {
        public ScmViewMenu()
        { 
            InitializeComponent(); 
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
            }
        }

        private void ScmViewMenu_Load(object sender, EventArgs e)
        {
            List<ScmStockItem> viewList = ScmEventMediator.OnStockView(null, new EventArgs());
            listView1.Columns.Add("Stock ID",60);
            listView1.Columns.Add("Item Name",85);
            listView1.Columns.Add("Price",55);
            listView1.Columns.Add("Arrival Date",120);
            listView1.Columns.Add("Quantity",60);
            listView1.Columns.Add("Min Quantity",75);
            listView1.Columns.Add("Max Quantity",75);

            int i = 0;

            foreach (ScmStockItem item in viewList)
            {
                listView1.Items.Add(item.stockId);            
                listView1.Items[i].SubItems.Add(item.stockName);
                listView1.Items[i].SubItems.Add("£" + item.stockPrice.ToString("N2"));
                listView1.Items[i].SubItems.Add(item.stockDate.ToString());
                listView1.Items[i].SubItems.Add(item.stockQty.ToString());
                listView1.Items[i].SubItems.Add(item.stockMin.ToString());
                listView1.Items[i].SubItems.Add(item.stockMax.ToString());
                i++;
            }
        }
    }
}
