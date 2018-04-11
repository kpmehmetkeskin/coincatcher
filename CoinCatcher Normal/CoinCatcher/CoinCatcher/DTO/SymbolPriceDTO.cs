using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinCatcher.DTO
{
    public class SymbolPriceDTO
    {
        public SymbolPriceDTO(string symbol, decimal newPrice, decimal oldPrice, Double incrementPercent)
        {
            this.symbol = symbol;
            this.newPrice = newPrice;
            this.oldPrice = oldPrice;
            this.incrementPercent = incrementPercent;
            this.incrementPower = 0;
            this.incrementHistory = "fffff";
        }

        public string symbol { get; set; }
        public decimal newPrice { get; set; }
        public decimal oldPrice { get; set; }
        public Double incrementPercent { get; set; }
        public decimal boughtQuantity { get; set; }
        public Double incrementPower { get; set; }
        public String incrementHistory { get; set; }
        
    }
}