using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MarketWatchApp
{
    public delegate void MarketDataHandler(MarketData price);

    public class MarketDataProvider
    {
        public event MarketDataHandler OnMarketData;
        private readonly Random random = new Random();
        private bool _stop;

        public bool Stop
        {
            get { return _stop; }
            set { _stop = value; }
        }

        public void GenerateMarketData()
        {
            //start
            MarketData InitialPrice = new MarketData();
            decimal closeprice = 0M;
            decimal openPrice = 0M;
            openPrice = Math.Round(Convert.ToDecimal(Gaussian()), 2);
            closeprice = openPrice - 1;
            InitialPrice.Symbol = "IBM";
            InitialPrice.OpenPrice = openPrice;
            InitialPrice.ClosePrice = closeprice;
            InitialPrice.LastPrice = openPrice;

            if (OnMarketData != null)
                OnMarketData(InitialPrice);

            InitialPrice = new MarketData();
            InitialPrice.Symbol = "MSFT";
            InitialPrice.OpenPrice = Convert.ToDecimal(Gaussian());
            InitialPrice.ClosePrice = InitialPrice.OpenPrice - 1;
            InitialPrice.LastPrice = Math.Round(Convert.ToDecimal(Gaussian()), 2);
            InitialPrice.PriceChange = InitialPrice.LastPrice - openPrice;

            if (OnMarketData != null)
                OnMarketData(InitialPrice);

            for (int i = 0; i < 1000; i++)
            {
                InitialPrice = new MarketData();
                InitialPrice.Symbol = "IBM";
                InitialPrice.OpenPrice = 34.56M;
                InitialPrice.ClosePrice = 34.45M;
                InitialPrice.LastPrice = 34 + Math.Round(Convert.ToDecimal(Gaussian()), 2);
                InitialPrice.PriceChange = InitialPrice.LastPrice - InitialPrice.OpenPrice;

                if (OnMarketData != null)
                    OnMarketData(InitialPrice);

                InitialPrice = new MarketData();
                InitialPrice.Symbol = "MSFT";
                InitialPrice.OpenPrice = 54.56M;
                InitialPrice.ClosePrice = 54.45M;
                InitialPrice.LastPrice = 54 + Math.Round(Convert.ToDecimal(Gaussian()), 2);
                InitialPrice.PriceChange = InitialPrice.LastPrice - InitialPrice.OpenPrice;

                if (OnMarketData != null)
                    OnMarketData(InitialPrice);

                InitialPrice = new MarketData();
                InitialPrice.Symbol = "DB";
                InitialPrice.OpenPrice = 20.45M;
                InitialPrice.ClosePrice = 20.40M;
                InitialPrice.LastPrice = 20 + Math.Round(Convert.ToDecimal(Gaussian()), 2);
                InitialPrice.PriceChange = InitialPrice.LastPrice - InitialPrice.OpenPrice;

                if (OnMarketData != null)
                    OnMarketData(InitialPrice);


                Thread.Sleep(100);

                if (_stop)
                    break;
            }

        }
        private string GenerateFakeMarketData()
        {
            return "CSCO " + string.Format("{0:##.##}", 22 + Math.Abs(Gaussian()));
        }

        private double Gaussian()
        {
            double x1, x2, w;

            do
            {
                x1 = 2.0 * random.NextDouble() - 1.0;
                x2 = 2.0 * random.NextDouble() - 1.0;
                w = x1 * x1 + x2 * x2;
            } while (w >= 1.0);

            w = Math.Sqrt(-2.0 * Math.Log(w) / w);

            // two Gaussian random numbers are generated
            return x1 * w;
            //y2 = x2 * w; 
        }
    }
}
