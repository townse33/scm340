using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scm340
{
    //Essentially a function pointer to event handlers
    //This specifies handlers that subscribe to SCM events
    public delegate void ScmEvent(object sender, EventArgs e);

    public class ScmEventMediator
    {
        //Declare each possible event the mediator will handle
      
        public static void OnStockAdded(object sender, EventArgs e)
        {
            ScmAdd gui = (ScmAdd)sender;
            if (ScmValidate.validStock(gui)) { ScmDataAccess.addStock(gui.submission); }
        }

        public static void OnStockView(object sender, EventArgs e)
        {
            ScmView gui = (ScmView)sender;
            gui.viewList = ScmDataAccess.readStock();
            ScmDataConvert.ViewConvert(gui);
        }

        public static void OnStockReport(object sender, EventArgs e)
        {
            ScmReport gui = (ScmReport)sender;
            gui.current_stock = ScmDataAccess.readStock();
            ScmDataFormat.reportFormat(gui);
        }
    }
}
