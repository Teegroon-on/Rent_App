using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Rent_App
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class AuthorizationWindow : Window
	{
		int EntryCol = 0;
		public AuthorizationWindow()
		{
			InitializeComponent();
			App.WindowApp.Add(this);
		}

		private void EntryButClick(object sender, RoutedEventArgs e)
		{
			EntryCol++;
			bool Access = true;
			bool CapchaAccess = false;
			if (LoginTB.Text != "" && LoginTB.Text != " " &&
				PassworB.Password != "" && PassworB.Password != " ")
			{
				if (EntryCol > 2)
				{
					if (CapchaImage.Text == CapchaTB.Text)
					{
						CapchaAccess = true;
					}
					if (CapchaAccess)
					{
						DataModel.STAFF StaffLogin = null;
						try
						{
							var Context = new DataModel.RentContext();
							StaffLogin = Context.STAFF.FirstOrDefault(p => p.Email == LoginTB.Text.ToLower());
						}
						catch (Exception ex)
						{
							MessageBox.Show("Ошибка базы данных. Обратитесь к системному администратору.",
								"Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
							Access = false;
						}

						if (StaffLogin.Email != null)
						{
							if (StaffLogin.Password == PassworB.Password)
							{
								switch (StaffLogin.Role_id)
								{
									case 2:
										{
											MenagerC MC = new MenagerC();
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
						MessageBox.Show("Неверное введен текст Капчи!", "Ошибка!",
										MessageBoxButton.OK, MessageBoxImage.Error);
						Access = false;

					}
				}
				else
				{
					DataModel.STAFF StaffLogin = null;
					try
					{
						var Context = new DataModel.RentContext();
						StaffLogin = Context.STAFF.FirstOrDefault(p => p.Email == LoginTB.Text);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Ошибка базы данных. Обратитесь к системному администратору.",
							"Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
						Access = false;
					}

					if (StaffLogin.Email != null)
					{
						if (StaffLogin.Password == PassworB.Password)
						{
							switch (StaffLogin.Role_id)
							{
								case 2:
									{
										MenagerC MC = new MenagerC();
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
			}
			else
			{
				MessageBox.Show("Для успешной авторизации, необходимо ввести и логин, и пароль.", ""
				, MessageBoxButton.OK, MessageBoxImage.Information);
				Access = false;
			}

			if(!Access && EntryCol> 2)
			{
				CapchaImage.Visibility = Visibility.Visible;
				CapchaTB.Visibility = Visibility.Visible;
				CapchaRefresh();
				
			}
		}

		private void CancleButClick(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void CapchaRefresh()
		{
			String allowchar = "";

			allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";

			allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";

			allowchar += "1,2,3,4,5,6,7,8,9,0";

			char[] a = { ',' };

			String[] ar = allowchar.Split(a);

			String pwd = "";

			string temp = "";

			Random r = new Random();



			for (int i = 0; i < 6; i++)

			{

				temp = ar[(r.Next(0, ar.Length))];



				pwd += temp;

			}
			CapchaImage.Text = pwd;
		}
	}
}
