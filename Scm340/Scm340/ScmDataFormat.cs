using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Scm340
{
    public static class ScmDataFormat
    {
        public static void viewFormat(int id, ScmStockItem item, ScmView gui)
        {
            string status_msg;

                if (item.stockQty == 0)
                {
                    status_msg = "Out of Stock";
                    gui.listView1.Items[id].BackColor = Color.LightPink;
                }
                else if (item.stockQty < 1.25f * item.stockMin)
                {
                    status_msg = "Stock Low";
                    gui.listView1.Items[id].BackColor = Color.Yellow;
                }
                else if (item.stockQty <= item.stockMax)
                {
                    status_msg = "In Stock";
                }
                else
                {
                    status_msg = "Surplus";
                    gui.listView1.Items[id].BackColor = Color.Yellow;
                }

            gui.listView1.Items[id].SubItems.Add(status_msg);
        }

        public static void reportFormat(ScmReport gui)
        {
            gui.chart1.Series.Remove(gui.chart1.Series[0]);
            gui.chart1.Series.Add("Stock Qty.");

            int i = 0;
            int j = 0;

            foreach (ScmStockItem stock_item in gui.current_stock)
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
