using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;

namespace MarketWatchApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MarketWatch : Window
	{
		MarketDataProvider provider;
		public ObservableCollection<MarketData> marketdatalist;
		List<MarketData> _list;

		public MarketWatch()
		{
			InitializeComponent();

			provider = new MarketDataProvider();

			_list = new List<MarketData>();

			marketdatalist = new ObservableCollection<MarketData>(_list);

			provider.OnMarketData += new MarketDataHandler(provider_OnMarketData);

		}


		void provider_OnMarketData(MarketData price)
		{
			if (!Dispatcher.CheckAccess())
			{
				Dispatcher.Invoke(() =>
				{
					int indx = _list.FindIndex(delegate (MarketData row)
												{
													return row.Symbol.Equals(price.Symbol);
												}
											);

					if (indx == -1)
					{
						_list.Add(price);
						marketdatalist.Add(price);
					}
					else
					{
						_list[indx] = price;
						marketdatalist[indx] = price;
					}
				});

				return;
			}
		}

		private void Btn1_Click(object sender, RoutedEventArgs e)
		{
			Task.Factory.StartNew(() => provider.GenerateMarketData());
		}

		private void grdEmployee_Loaded(object sender, RoutedEventArgs e)
		{
			(sender as DataGrid).ItemsSource = marketdatalist;
		}
	}
}
