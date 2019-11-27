using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Rent_App.ViewModel
{
    class ViewModelShopCenter : DependencyObject
    {
		public ICollectionView Items
		{
			get { return (ICollectionView)GetValue(ItemsProperty); }
			set { SetValue(ItemsProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty ItemsProperty =
			DependencyProperty.Register("Items", typeof(ICollectionView), typeof(ViewModelShopCenter), new PropertyMetadata(null));

		public ViewModelShopCenter()
		{
			var Context = new DataModel.RentContext();
			/*var Items  = from ShopCenter in Context.V_SHOP_CENTER
							  group new
							  {
								  Name = ShopCenter.Name,
								  StatusSC = ShopCenter.Status,
								  PavilionCol = ShopCenter.Pavilion_col,
								  CitySC = ShopCenter.City,
								  CostBuild = ShopCenter.Price,
								  FloorCol = ShopCenter.Floor_col,
								  Coff = ShopCenter.Coff_advance_price
							  }
							  by new { ShopCenter.Status, ShopCenter.City } into g1
							  orderby g1.Key
							  select g1;*/

			var Test = Context.V_SHOP_CENTER.ToList();
			Test.()
			Items = CollectionViewSource.GetDefaultView(Items);
			//Items = BufferTable;
			//Items.Filter = FilterPerson;
		}
	}
}
