using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinCatcher.Entity
{
    public class SymbolPrice
    {
        [JsonProperty]
        public string Symbol { get; set; }
        [JsonProperty]
        public decimal Price { get; set; }
        //[JsonProperty]
        //public decimal QuoteVolume { get; set; }
        //[JsonProperty]
        //public Double PriceIncrementPercent { get; set; }
        //public Double VolumeIncrementPercent { get; set; }
        [JsonProperty]
        public Double PricePower { get; set; }
        //public Double VolumePower{ get; set; }
        //public Double Power { get; set; }

        public SymbolPrice(String Symbol, Double PricePower, Double VolumePower, Double Power)
        {
            this.Symbol = Symbol;
            this.PricePower = PricePower;
            //this.VolumePower = VolumePower;
            //this.Power = Power;
        }

        public SymbolPrice()
        {
            PricePower = 0.0;
            //VolumePower = 0.0;
        }
    }

    public class SymbolPriceResponse
    {
        [JsonProperty]
        private List<SymbolPrice> data = null;
        public SymbolPriceResponse(List<SymbolPrice> data)
        {
            this.data = data;
        }
    }
}