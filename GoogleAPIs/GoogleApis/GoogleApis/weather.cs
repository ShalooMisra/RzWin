using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GmailAPI
{
    class weather
    {


        public string GetWeather()
        {
            string ret = "";
            var client = new RestClient("http://www.google.com/ig/api");
            var request = new RestRequest(Method.GET);
            request.AddParameter("weather", "Brisbane");

            var response = client.Execute<xml_api_reply>(request);
            ret = response.ToString();
            return ret;
        }




        public class xml_api_reply
        {
            public string version { get; set; }
            public Weather weather { get; set; }
        }
        public class Weather : List<Forecast_Conditions>
        {
            public Forecast_Information Forecast_Information { get; set; }
            public Current_Conditions Current_Conditions { get; set; }
        }
        public class DataElement
        {
            public string Data { get; set; }
        }
        public class Forecast_Information
        {
            public DataElement City { get; set; }
            public DataElement Postal_Code { get; set; }
            public DataElement Forecast_Date { get; set; }
            public DataElement Unit_System { get; set; }
        }
        public class Current_Conditions
        {
            public DataElement Condition { get; set; }
            public DataElement Temp_c { get; set; }
            public DataElement Humidity { get; set; }
            public DataElement Icon { get; set; }
            public DataElement Wind_condition { get; set; }
        }
        public class Forecast_Conditions
        {
            public DataElement Day_Of_Week { get; set; }
            public DataElement Condition { get; set; }
            public DataElement Low { get; set; }
            public DataElement High { get; set; }
            public DataElement Icon { get; set; }
        }



    }
}
