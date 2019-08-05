using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DataLayer
{
    class Program
    {
        private const string URL = "https://goonmetrics.apps.goonswarm.org/api/price_data/";
        private const string urlParameters = "?station_id=60003760&type_id=34,35,36,37";
        public static Dictionary<string, string> typeid = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            DataCollection dataCollection = new DataCollection();
            dataCollection.getTypeId();
            dataCollection.getHttpResponseGoonmetrics();
        }




    }
}
