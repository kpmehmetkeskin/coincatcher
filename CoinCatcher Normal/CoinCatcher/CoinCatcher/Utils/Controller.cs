using System;
using System.Collections.Generic;
using System.Linq;
using CoinCatcher.DTO;
using CoinCatcher.Entity;

namespace CoinCatcher.Utils
{
    public class Controller
    {
        List<SymbolPriceDTO> watchMinByMinList = null;
        List<SymbolPrice> oldSymbolPriceList = null;
        private Connection connection = new Connection();

        public List<SymbolPriceDTO> checkForBuy()
        {
            List<SymbolPrice> symbolPriceList = connection.getAllPrices();
            List<SymbolPriceDTO> retList = null;
            /*  Program ilk açıldıgında bir kıyaslama yapılamaz dıye buraya girmeyecek*/
            if (oldSymbolPriceList != null)
            {
                retList = getMinByMin(symbolPriceList, oldSymbolPriceList);                
            }
            oldSymbolPriceList = new List<SymbolPrice>(symbolPriceList);

            return retList;
        }

        private List<SymbolPriceDTO> getMinByMin(List<SymbolPrice> newList, List<SymbolPrice> oldList)
        {
            List<SymbolPriceDTO> symbolPriceDTOList = new List<SymbolPriceDTO>();
            SymbolPriceDTO symbolPriceDTO = null;
            foreach (SymbolPrice itemNew in newList)
            {
                foreach (SymbolPrice itemOld in oldList)
                {
                    if (itemNew.Symbol.Equals(itemOld.Symbol) && !itemNew.Symbol.Contains("ETH") && !itemNew.Symbol.Contains("BNB") && !itemNew.Symbol.Contains("USDT"))
                    {
                        Double incrementPercent = (Double)(itemNew.Price / itemOld.Price);
                        symbolPriceDTO = new SymbolPriceDTO(itemNew.Symbol.Replace("BTC",""), itemNew.Price, itemOld.Price, incrementPercent);
                        symbolPriceDTOList.Add(symbolPriceDTO);
                        // watchMinByMinList kaldırılabilir. Buraya tasınabılır.
                    }
                }
            }

            if (watchMinByMinList == null)
            {
                watchMinByMinList = symbolPriceDTOList;
            }
            //f:fixed u:up d:down
            foreach (SymbolPriceDTO w in watchMinByMinList)
            {
                foreach (SymbolPriceDTO s in symbolPriceDTOList)
                {
                    if (w.symbol.Equals(s.symbol))
                    {
                        if (s.incrementPercent > 1.0d)
                        {
                            w.incrementPower += 9.99;
                            w.incrementHistory = addQueue(w.incrementHistory, "u");
                        }
                        else if (s.incrementPercent < 1.0d)
                        {
                            w.incrementPower -= 9.99;
                            w.incrementHistory = addQueue(w.incrementHistory, "d");
                        }
                        else
                        {
                            if (w.incrementPower > 0 && w.incrementPower < 100)
                            {
                                w.incrementPower -= 0.97;
                                w.incrementHistory = addQueue(w.incrementHistory, "f");
                            }
                        }

                        if (w.incrementPower < 0)
                        {
                            w.incrementPower = 0;
                        }
                        else if(w.incrementPower > 100)
                        {
                            w.incrementPower = 100;
                        }
                    }
                }
                w.incrementPower = Math.Round(w.incrementPower, 2);

            }
            watchMinByMinList = watchMinByMinList.OrderByDescending(a => a.incrementPower).ToList<SymbolPriceDTO>();

            return watchMinByMinList;
        }

        private String addQueue(String destination, String character)
        {
            try
            {
                destination += character;
                destination = destination.Remove(0, 1);
            }
            catch (Exception)
            {
                return "fffff";
            }

            return destination;
        }



    }
}