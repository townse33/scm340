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
    public partial class ScmMainMenu : Form
    /* This partial class acts as an interface to program the GUI behaviour without directly
     * coding the GUI appearance which is rather verbose and was generated using the
     * Windows Form Designer */
    {
        public ScmMainMenu()
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
                    temp_form = new ScmAddMenu();
                    temp_form.Show();
                    this.Hide();
                    break;

                case "ViewButton":
                    temp_form = new ScmViewMenu();
                    temp_form.Show();
                    this.Hide();
                    break;

                case "ReportButton":
                    break;

                case "ExitButton":
                    //Ends program with exit code 1 (equivalent to returning 1 on a main method)
                    System.Environment.Exit(1);
                    break; 
            }

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ScmMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
