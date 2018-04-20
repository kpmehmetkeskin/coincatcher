using CoinCatcher.DTO;
using CoinCatcher.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoinCatcher.Utils
{
    public class Services
    {
        private Connection connection = new Connection();
        private List<SymbolPrice> coinListTemp = null;

        public List<SymbolPrice> getCoinPowerAndVolumeInc()
        {
            List<SymbolPrice> coinList = GetBtcCoins(connection.getDataFromBinance());

            if (coinListTemp != null)
            {
                coinList = CompareCoinListsandGetPowers(coinList);

            } 
            
            coinListTemp = new List<SymbolPrice>(coinList);

            return coinList;
        }

        private List<SymbolPrice> CompareCoinListsandGetPowers(List<SymbolPrice> pCoinList)
        {
            foreach (SymbolPrice pCoin in pCoinList)
            {
                foreach (SymbolPrice pCoinTemp in coinListTemp)
                {
                    if (pCoin.Symbol.Equals(pCoinTemp.Symbol))
                    {
                        Double priceIncrementPercent = (Double)(pCoin.LastPrice / pCoinTemp.LastPrice);
                        Double volumeIncrementPercent = (Double)(pCoin.QuoteVolume / pCoinTemp.QuoteVolume);

                        if (priceIncrementPercent > 1.0d)
                        {
                            pCoin.PricePower = pCoinTemp.PricePower + (9.99 * priceIncrementPercent);
                        }
                        else if (priceIncrementPercent < 1.0d)
                        {
                            pCoin.PricePower = pCoinTemp.PricePower - (9.99 * priceIncrementPercent);
                        }
                        else
                        {
                            pCoin.PricePower = pCoinTemp.PricePower - (0.97 * priceIncrementPercent);
                        }
                        //  ---------------------------------------
                        if (volumeIncrementPercent > 1.0d)
                        {
                            pCoin.VolumePower = pCoinTemp.VolumePower + (2.99 * volumeIncrementPercent);
                        }
                        else if (volumeIncrementPercent < 1.0d)
                        {
                            pCoin.VolumePower = pCoinTemp.VolumePower - (2.99 * volumeIncrementPercent);
                        }
                        else
                        {
                            pCoin.VolumePower = pCoinTemp.VolumePower - (0.97 * volumeIncrementPercent);
                        }
                        //  ---------------------------------------
                        if (pCoin.PricePower > 100)
                        {
                            pCoin.PricePower = 100;
                        }
                        else if (pCoin.PricePower < 0)
                        {
                            pCoin.PricePower = 0;
                        }
                        else
                        {
                            pCoin.PricePower = Math.Round(pCoin.PricePower, 2);
                        }
                        //  ---------------------------------------
                        if (pCoin.VolumePower > 100)
                        {
                            pCoin.VolumePower = 100;
                        }
                        else if (pCoin.VolumePower < 0)
                        {
                            pCoin.VolumePower = 0;
                        }
                        else
                        {
                            pCoin.VolumePower = Math.Round(pCoin.VolumePower, 2);
                        }
                        //  ---------------------------------------
                        pCoin.Power = Math.Round((pCoin.PricePower * pCoin.VolumePower) / 100, 2);
                        //  ---------------------------------------
                        Boolean isSameCoin = false;
                        if (_Default.pumpedCoins.Count > 0 && _Default.pumpedCoins.ElementAt(_Default.pumpedCoins.Count - 1).symbol.Equals(pCoin.Symbol))
                        {
                            isSameCoin = true;
                        }

                        if (pCoin.Power == 100 && !isSameCoin)
                        {
                            _Default.pumpedCoins.Enqueue(new SymbolPriceDTO(pCoin.Symbol, DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()));

                            if (_Default.pumpedCoins.Count > 50)
                            {
                                _Default.pumpedCoins.Dequeue();
                            }
                        }
                        //  ---------------------------------------
                    }
                }
            }
            pCoinList = pCoinList.OrderByDescending(a => a.Power).ToList<SymbolPrice>();
            return pCoinList;
        }

        private List<SymbolPrice> GetBtcCoins(List<SymbolPrice> pList)
        {
            List<SymbolPrice> list = new List<SymbolPrice>();

            foreach (SymbolPrice symbolPrice in pList)
            {
                if (!symbolPrice.Symbol.Contains("ETH") && !symbolPrice.Symbol.Contains("BNB") && !symbolPrice.Symbol.Contains("USDT"))
                {
                    symbolPrice.Symbol = symbolPrice.Symbol.Replace("BTC","");
                    list.Add(symbolPrice);
                }
            }
            return list;
        }
    }
}