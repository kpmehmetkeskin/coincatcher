using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinCatcher.Entity
{
    public class SymbolPrice
    {
        //[JsonProperty("symbol")]
        public string Symbol { get; set; }
        //[JsonProperty("price")]
        public decimal Price { get; set; }
    }
}