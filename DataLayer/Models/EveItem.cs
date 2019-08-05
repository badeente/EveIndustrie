using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models

{
    public class EveItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public double max_Buy { get; set; }
        public double min_Sell { get; set; }


        public string toString()
        {
            return "ID: " + id + " Name: "+ name + " Max_Buy: " + max_Buy + " Min_Sell: " + min_Sell;
        }
    }
}
