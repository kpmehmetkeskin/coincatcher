using CoinCatcher.DTO;
using CoinCatcher.Entity;
using CoinCatcher.Properties;
using CoinCatcher.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoinCatcher
{
    public partial class _Default : Page
    {
        static List<SymbolPrice> list = null;
        public static Queue<SymbolPriceDTO> pumpedCoins = new Queue<SymbolPriceDTO>();
        static Services services;

        static _Default()
        {
            services = new Services();

            method = delegate
            {
                try
                {
                    list = services.getCoinPowerAndVolumeInc();
                }
                catch (Exception e)
                {
                }
            };
            (thr = new Thread(new ParameterizedThreadStart(delegate
            {
                while (true)
                {
                    method();
                    Thread.Sleep(10000);
                }
            }))).Start();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static Thread thr;
        public delegate void Method();
        public static Method method;

        public static List<SymbolPrice> getList()
        {
            if (list == null)
                return new List<SymbolPrice>();

            return list;
        }
    }
}