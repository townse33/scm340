using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scm340
{
    public static class ScmDataConvert
    {
        public static void ViewConvert(ScmView gui)
        {
            gui.listView1.Columns.Add("Stock ID", 60);
            gui.listView1.Columns.Add("Item Name", 85);
            gui.listView1.Columns.Add("Price", 55);
            gui.listView1.Columns.Add("Arrival Date", 120);
            gui.listView1.Columns.Add("Quantity", 60);
            gui.listView1.Columns.Add("Min Quantity", 75);
            gui.listView1.Columns.Add("Max Quantity", 75);
            gui.listView1.Columns.Add("Status", 85);

            int i = 0;

            foreach (ScmStockItem item in gui.viewList)
            {
                gui.listView1.Items.Add(item.stockId);
                gui.listView1.Items[i].SubItems.Add(item.stockName);
                gui.listView1.Items[i].SubItems.Add("£" + item.stockPrice.ToString("N2"));
                gui.listView1.Items[i].SubItems.Add(item.stockDate.ToString());
                gui.listView1.Items[i].SubItems.Add(item.stockQty.ToString());
                gui.listView1.Items[i].SubItems.Add(item.stockMin.ToString());
                gui.listView1.Items[i].SubItems.Add(item.stockMax.ToString());

                ScmDataFormat.viewFormat(i, item, gui);
                i++;
            }
        }
    }
}
