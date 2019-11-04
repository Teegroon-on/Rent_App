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
using System.Windows.Shapes;

namespace Rent_App
{
	/// <summary>
	/// Логика взаимодействия для Menager_C.xaml
	/// </summary>
	public partial class MenagerC : Window
	{
		public MenagerC()
		{
			InitializeComponent();
			App.WindowApp.Add(this);
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
