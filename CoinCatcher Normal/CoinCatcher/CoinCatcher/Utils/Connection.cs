using CoinCatcher.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace CoinCatcher.Utils
{
    public class Connection
    {

        String html = "";
        String url = "";

        public Connection()
        {
            html = string.Empty;
            url = @"https://api.binance.com/api/v1/ticker/24hr";
        }

        public List<SymbolPrice> getDataFromBinance()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            List<SymbolPrice> symbolPriceList = JsonConvert.DeserializeObject<List<SymbolPrice>>(html);

            return symbolPriceList;
        }



        
    }
}