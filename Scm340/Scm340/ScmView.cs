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
    public partial class ScmView : Form
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

        public ScmView()
        {
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

        private void ScmView_Load(object sender, EventArgs e)
        {
            List<ScmStockItem> viewList = ScmEventMediator.OnStockView(null, new EventArgs());
            listView1.Columns.Add("Stock ID", 60);
            listView1.Columns.Add("Item Name", 85);
            listView1.Columns.Add("Price", 55);
            listView1.Columns.Add("Arrival Date", 120);
            listView1.Columns.Add("Quantity", 60);
            listView1.Columns.Add("Min Quantity", 75);
            listView1.Columns.Add("Max Quantity", 75);
            listView1.Columns.Add("Status", 85);

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

                string status_msg;

                if (item.stockQty == 0)
                {
                    status_msg = "Out of Stock";
                    listView1.Items[i].BackColor = Color.LightPink;
                }
                else if (item.stockQty < 1.25f * item.stockMin)
                {
                    status_msg = "Stock Low";
                    listView1.Items[i].BackColor = Color.Yellow;
                }
                else if (item.stockQty <= item.stockMax)
                {
                    status_msg = "In Stock";
                }
                else
                {
                    status_msg = "Surplus";
                    listView1.Items[i].BackColor = Color.Yellow;
                }

                listView1.Items[i].SubItems.Add(status_msg);
                i++;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            panel4.BackColor = Color.FromArgb(52, 159, 219);
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.FromArgb(64, 64, 64);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Form temp_form = new ScmAdd();
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
    }
}
