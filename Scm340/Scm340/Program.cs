using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scm340
{
    static class Program
    {
        //I use a static field to keep track of the main menu at all times
        //This prevents any memory issues associated with creating more
        //The program terminates if the main form is destroyed
        public static Form MainForm;

        [STAThread]
        static void Main()
        {
            //Initialise services for windows forms
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Assign the main menu to the main form field, then run the program from this form
            MainForm = new ScmMainMenu();
            Application.Run(MainForm);
        }
    }

    
}
