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
