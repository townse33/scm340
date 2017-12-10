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
        public event ScmEvent StockView;
        public event ScmEvent StockReport;

        public static void OnStockAdded(object sender, EventArgs e)
        {
            ScmStockItem temp_item = (ScmStockItem)sender;
            ScmDataAccess.addStock(temp_item);
        }

        public static List<ScmStockItem> OnStockView(object sender, EventArgs e)
        {
            return ScmDataAccess.readStock();
        }

        public static void OnStockReport(object sender, EventArgs e)
        {
            ScmReport gui = (ScmReport)sender;
            gui.chart1.Series.Remove(gui.chart1.Series[0]);
            gui.chart1.Series.Add("Stock Qty.");
            List<ScmStockItem> current_stock = ScmDataAccess.readStock();
            int i = 0;
            int j = 0;

            foreach (ScmStockItem stock_item in current_stock)
            {
                gui.chart1.Series[0].Points.InsertXY(0, stock_item.stockName, stock_item.stockQty);
                i++;
                j += stock_item.stockQty / stock_item.stockMin;
            }

            if (j / i < 1)
            {
                gui.label6.Text = "Stock is low on average, re-orders required.";
            }

            else 
            {
                gui.label6.Text = "Stock is generally healthy overall.";
            }
        }
    }
}
