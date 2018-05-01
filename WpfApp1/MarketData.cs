using System.ComponentModel;

namespace MarketWatchApp
{    
    public class MarketData: INotifyPropertyChanged

	{
		private string _symbol;
		private decimal _lastPrice;
		private decimal _priceChange;
		private decimal _closePrice;
		private decimal _openPrice;

		public string Symbol
        {
			get { return _symbol; }
			set
			{
				_symbol = value;
				NotifyPropertyChanged("Symbol");
			}
		}

		public decimal LastPrice
		{
			get { return _lastPrice; }
			set
			{
				_lastPrice = value;
				NotifyPropertyChanged("LastPrice");
			}
		}

		public decimal PriceChange
		{
			get { return _priceChange; }
			set
			{
				_priceChange = value;
				NotifyPropertyChanged("PriceChange");
			}
		}

		public decimal ClosePrice
		{
			get { return _closePrice; }
			set
			{
				_closePrice = value;
				NotifyPropertyChanged("ClosePrice");
			}
		}

		public decimal OpenPrice
		{
			get { return _openPrice; }
			set
			{
				_openPrice = value;
				NotifyPropertyChanged("OpenPrice");
			}
		}



		public event PropertyChangedEventHandler PropertyChanged;

		private void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
