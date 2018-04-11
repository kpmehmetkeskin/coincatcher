using CoinCatcher.DTO;
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
        static List<SymbolPriceDTO> list = null;
        static Controller controller  = null;

        static _Default()
        {
            controller = new Controller();

            method = delegate
            {
                try
                {
                    list = controller.checkForBuy();
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
                    Thread.Sleep(1000);
                }
            }))).Start();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public static Thread thr;
        public delegate void Method();
        public static Method method;

        public static List<SymbolPriceDTO> getList()
        {
            if (list == null)
                return new List<SymbolPriceDTO>();

            return list;
        }
    }
}