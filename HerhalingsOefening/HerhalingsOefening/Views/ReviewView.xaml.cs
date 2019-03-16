using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using HerhalingsOefening.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HerhalingsOefening.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReviewView : ContentPage
	{
		public ReviewView(Restaurant selectedRestaurant)
		{
			InitializeComponent ();
		    BindingContext = App.Locator.ReviewViewModel;
		    App.Locator.ReviewViewModel.Restaurant = selectedRestaurant;

		}
	}
}