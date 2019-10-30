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

namespace Rent_App
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void EntryButClick(object sender, RoutedEventArgs e)
		{
			if (LoginTB.Text != "" && LoginTB.Text != " ")
			{
				var Context = new DataModel.RentContext();
				DataModel.STAFF StaffLogin = Context.STAFF.FirstOrDefault(p => p.Email == LoginTB.Text);
				if(StaffLogin.Email != null )
				{
					if(StaffLogin.Password == PassworB.Password)
					{
						switch(StaffLogin.Role_id)
						{
							case 2:
								{
									Menager_C MC = new Menager_C();
									MC.Show();
									this.Hide();
									break;
								}
							default:
								{
									MessageBox.Show("Доступ ограничен, для получения доступа обратитесь к администратору системы.", ""
													, MessageBoxButton.OK, MessageBoxImage.Information);
									break;
								}
						}
					}
					else
					{
						MessageBox.Show("Неверный пароль пользователя.", ""
							, MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
				else
				{
					MessageBox.Show("Пользователя с таким Email нет в базе данных.", ""
						, MessageBoxButton.OK, MessageBoxImage.Information);
				}
			}
			else
			{
				MessageBox.Show("Введите Email.", ""
					, MessageBoxButton.OK, MessageBoxImage.Information);
			}
		}

		private void CancleButClick(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
