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
        public event ScmEvent StockAdded;
        public event ScmEvent StockModified;

        public static void OnStockAdded(object sender, EventArgs e)
        {
            ScmStockItem temp_item = (ScmStockItem)sender;
            ScmDataAccess.addStock(temp_item);
        }
    }
}
