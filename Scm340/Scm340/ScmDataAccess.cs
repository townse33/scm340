using System;
using System.Xml.Linq;

namespace Scm340
{

    public static class ScmDataAccess
    {
        //This class handles any XML operations required to fetch or store stock data

        public static string dbName = "scm.xml";

        public static bool dbExists()
        {
            return System.IO.File.Exists(dbName);
        }

        public static void initDb()
        {
            if (!dbExists())
            {
                //Create new XML Document containing the root element 'StockTable'
                //Save this document as the database name specified in the class
                new XDocument(new XElement("StockTable")).Save(dbName);
            }
        }

        public static void addStock(ScmStockItem item)
        {
            initDb(); //I never assume the database exists
            XDocument db = XDocument.Load(dbName);

            //Add a new item as a child of the root element 'StockTable'
            //We use the stock ID as the sole attribute of the new child for easy searching
            XElement temp_item = new XElement(item.stockId);

            //We add a child node for each attribute
            //This is an easily readable way to ensure we don't excessively nest nodes
            temp_item.Add(new XElement("stockName", item.stockName));
            temp_item.Add(new XElement("stockPrice", item.stockPrice));
            temp_item.Add(new XElement("stockQty", item.stockQty));
            temp_item.Add(new XElement("stockDate", item.stockDate));
            temp_item.Add(new XElement("stockMin", item.stockMin));
            temp_item.Add(new XElement("stockMax", item.stockMax));

            db.Root.Add(temp_item);

            db.Save(dbName);
        }
    }

    public struct ScmStockItem
    {
        //Data structure to represent a single stock item
        //This acts as an intermediate representation between the GUI and DB

        public string stockId, stockName;

        public float stockPrice;

        public DateTime stockDate;

        public int stockQty, stockMin, stockMax;

        //Stock item constructor, all attributes are mandatory so we get them at construction
        public ScmStockItem(string id, string name, float price, DateTime date, int qty, int min, int max)
        {
            stockId = id;
            stockName = name;
            stockPrice = price;
            stockDate = date;
            stockQty = qty;
            stockMin = min;
            stockMax = max;
        }
    }

}