using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scm340
{
    public static class ScmValidate
    {
        public static bool validStock(ScmAdd gui)
        {
            if (gui.missingCode) { MessageBox.Show("Please enter a product code"); return false; };
            if (gui.missingName) { MessageBox.Show("Please enter a product name"); return false; };
            if (gui.invalidPrice) { MessageBox.Show("Please enter a valid price"); return false; };
            if (gui.invalidQty) { MessageBox.Show("Please enter a valid quantity"); return false; };
            if (gui.invalidMin) { MessageBox.Show("Please enter a valid minimum quantity"); return false; };
            if (gui.invalidMax) { MessageBox.Show("Please enter a valid maximum quantity"); return false; };
            return true;
        }
    }
}
