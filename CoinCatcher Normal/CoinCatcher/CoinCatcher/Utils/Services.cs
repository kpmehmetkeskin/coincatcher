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
        private Double generalPriceAverage = 0.0;

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
            generalPriceAverage = 0.0;
            foreach (SymbolPrice pCoin in pCoinList)
            {
                foreach (SymbolPrice pCoinTemp in coinListTemp)
                {
                    if (pCoin.Symbol.Equals(pCoinTemp.Symbol))
                    {
                        Double priceIncrementPercent = (Double)(pCoin.Price / pCoinTemp.Price);

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
                        generalPriceAverage += pCoin.PricePower;
                        pCoin.PricePower = Math.Round(pCoin.PricePower, 2);
                        pCoin.Symbol = pCoin.Symbol.Replace("BTC","");
                        //  ---------------------------------------
                        Boolean isSameCoin = false;
                        if (_Default.pumpedCoins.Count > 0 && _Default.pumpedCoins.ElementAt(_Default.pumpedCoins.Count - 1).symbol.Equals(pCoin.Symbol))
                        {
                            isSameCoin = true;
                        }
                        if (pCoin.PricePower == 100 && !isSameCoin)
                        {
                            _Default.pumpedCoins.Enqueue(new SymbolPriceDTO(pCoin.Symbol, DateTime.Now.ToShortDateString() + " " + DateTime.Now.AddHours(+1).ToLongTimeString()));

                            if (_Default.pumpedCoins.Count > 50)
                            {
                                _Default.pumpedCoins.Dequeue();
                            }
                        }
                        //  ---------------------------------------
                        break;
                    }
                }
            }
            pCoinList = pCoinList.OrderByDescending(a => a.PricePower).ToList<SymbolPrice>();
            calculateBullishBearish(Convert.ToInt32(Math.Round(generalPriceAverage / pCoinList.Count * 8)));

            return pCoinList;
        }

        private void calculateBullishBearish(int value)
        {
            _Default.bullishBearishDTO.bullishPercent = value;
            _Default.bullishBearishDTO.bearishPercent = 100 - value;
        }

        private List<SymbolPrice> GetBtcCoins(List<SymbolPrice> pList)
        {
            List<SymbolPrice> list = new List<SymbolPrice>();

            foreach (SymbolPrice symbolPrice in pList)
            {
                if (!symbolPrice.Symbol.Contains("ETH") && !symbolPrice.Symbol.Contains("BNB") && !symbolPrice.Symbol.Contains("USDT") && !symbolPrice.Symbol.Contains("123"))
                {
                    symbolPrice.Symbol = symbolPrice.Symbol.Replace("BTC", "");
                    list.Add(symbolPrice);
                }
            }
            return list;
        }
    }
}