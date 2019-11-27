using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Rent_App
{
	/// <summary>
	/// Логика взаимодействия для Menager_C.xaml
	/// </summary>
	public partial class MenagerC : Window
	{
		/*public ObservableCollection<DataModel.V_SHOP_CENTER> DataShop = new ObservableCollection<DataModel.V_SHOP_CENTER>();
		public ObservableCollection<string> ChooseStatus { get; set; }
		public ObservableCollection<string> ChooseCity { get; set; }
		private DataModel.SHOP_CENTER SelectedUser_Item;*/

		public MenagerC()
		{
			InitializeComponent();
			App.WindowApp.Add(this);

			var Context = new DataModel.RentContext();
			var Buffer = Context.STATUS_SC.Select(p => p.Status);
			/*ChooseStatus.Add("Все");
			foreach (string item in Buffer)
			{
				ChooseStatus.Add(item);
			}
			StatusCB.ItemsSource = ChooseStatus;

			Buffer = Context.CITies.Select(p => p.City1);
			ChooseCity.Add("Все");
			foreach (string item in Buffer)
			{
				ChooseCity.Add(item);
			}
			CityCB.ItemsSource = ChooseCity;*/

			CityCheck.IsChecked = false;
			CityCB.IsEnabled = false;
			StatusCheck.IsChecked = false;
			StatusCB.IsEnabled = false;

			DataContext = new ViewModel.ViewModelShopCenter();
			/*var BufferTable = from ShopCenter in Context.V_SHOP_CENTER
							  group ShopCenter by new { ShopCenter.Status, ShopCenter.City } into g1
							  orderby g1
							  select new
							  {
								  Name = g1.Select(p => p.Name),
								  StatusSC = g1.Select(p => p.Status),
								  PavilionCol = g1.Select(p => p.Pavilion_col),
								  CitySC = g1.Select(p => p.City),
								  CostBuild = g1.Select(p => p.Price),
								  FloorCol = g1.Select(p => p.Floor_col),
								  Coff = g1.Select(p => p.Coff_advance_price)
							  };


			foreach(var item in BufferTable)
			{

			}*/

		}

		private void AddClick(object sender, RoutedEventArgs e)
		{

		}

		private void UpdClick(object sender, RoutedEventArgs e)
		{

		}

		private void DelClick(object sender, RoutedEventArgs e)
		{

		}

		private void BackClick(object sender, RoutedEventArgs e)
		{
			App.WindowApp[0].Show();
			App.WindowApp.RemoveAt(1);
			this.Close();
		}

		private void ExitClick(object sender, RoutedEventArgs e)
		{
			App.WindowApp[0].Show();
			App.WindowApp.RemoveAt(1);
			this.Close();
		}
	}
}
