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
		int EntryCol = 0;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void EntryButClick(object sender, RoutedEventArgs e)
		{
			EntryCol++;
			bool Access = true;
			if (LoginTB.Text != "" && LoginTB.Text != " ")
			{
				DataModel.STAFF StaffLogin = null;
				try
				{
					var Context = new DataModel.RentContext();
					StaffLogin = Context.STAFF.FirstOrDefault(p => p.Email == LoginTB.Text);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Ошибка базы данных. Обратитесь к системному администратору.",
						"Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
					Access = false;
				}

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
									Access = false;
									break;
								}
						}
					}
					else
					{
						MessageBox.Show("Неверный пароль пользователя.", ""
							                            , MessageBoxButton.OK, MessageBoxImage.Information);
						Access = false;
					}
				}
				else
				{
					MessageBox.Show("Пользователя с таким Email нет в базе данных.", ""
						, MessageBoxButton.OK, MessageBoxImage.Information);
					Access = false;
				}
			}
			else
			{
				MessageBox.Show("Введите Email.", ""
					, MessageBoxButton.OK, MessageBoxImage.Information);
				Access = false;
			}

			if(!Access && EntryCol>)
			{

			}
		}

		private void CancleButClick(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}
	}
}
