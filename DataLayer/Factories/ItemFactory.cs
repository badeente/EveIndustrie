using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace DataLayer.Factories
{
    public static class ItemFactory
    {


        public static void createItemList(string responseString, Dictionary<string, string> typeid)
        {
            XDocument xmlDocRaw = XDocument.Parse(responseString);
            XElement xmlTreeRaw = XElement.Parse(responseString);

            IEnumerable<XElement> de =
                from el in xmlTreeRaw.Descendants()
                select el;

            foreach (XElement el in de)
            {
                if (el.Name == "type")
                {
                    Models.EveItem item = new Models.EveItem();
                    item.id = el.Attribute("id").Value;
                    item.name = typeid.GetValueOrDefault(item.id);
                    XElement max_buy = el.Element("buy").Element("max");
                    item.max_Buy = double.Parse(max_buy.Value);
                    XElement min_sell = el.Element("sell").Element("min");
                    item.min_Sell = double.Parse(min_sell.Value);
                }
            }
        }


    }
}
