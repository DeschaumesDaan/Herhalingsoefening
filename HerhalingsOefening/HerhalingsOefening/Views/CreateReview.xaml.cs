using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerhalingsOefening.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HerhalingsOefening.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateReview : ContentPage
	{
		public CreateReview (Restaurant selectedRestaurant)
		{
			InitializeComponent ();
		    BindingContext = App.Locator.CreateReviewViewModel;
		    App.Locator.CreateReviewViewModel.Restaurant = selectedRestaurant;
		}
	}
}