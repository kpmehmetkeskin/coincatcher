using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinCatcher.Entity
{
    public class SymbolPrice
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal QuoteVolume { get; set; }

        public Double PriceIncrementPercent { get; set; }
        //public Double VolumeIncrementPercent { get; set; }

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
}