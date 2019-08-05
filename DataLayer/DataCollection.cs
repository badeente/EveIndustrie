using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DataLayer
{
    class DataCollection
    {
        private const string URL = "https://goonmetrics.apps.goonswarm.org/api/price_data/";
        private const string urlParameters = "?station_id=60003760&type_id=34,35,36,37";
        public static Dictionary<string, string> typeid = new Dictionary<string, string>();

        public void getTypeId()
        {
            using (StreamReader sr = new StreamReader("Data/typeids.csv"))
            {
                string _line;
                while ((_line = sr.ReadLine()) != null)
                {
                    string[] keyvalue = _line.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        try
                        {
                            typeid.Add(keyvalue[0], keyvalue[1]);
                            Console.WriteLine(keyvalue[0] + keyvalue[1]);
                            if (keyvalue[0] == "371027")
                            {
                                break;
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }

        public string getHttpResponseGoonmetrics()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            string responseString = "";

            // Add an Accept heador for XML Format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsStringAsync().Result;
                foreach (var d in dataObjects)
                {
                    responseString += d.ToString();
                }

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            Console.ReadKey();
            return responseString;

        }
    }
}
