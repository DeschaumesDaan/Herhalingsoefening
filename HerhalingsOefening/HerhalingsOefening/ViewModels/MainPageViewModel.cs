using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HerhalingsOefening.Models;
using HerhalingsOefening.Services;
using OnBoardingOefening.Services;
using Xamarin.Forms;

namespace HerhalingsOefening.ViewModels
{
    public class MainPageViewModel:ViewModelBase
    {
        private readonly IRestaurantAppService _restaurantAppService;
        private readonly ICustomNavigation _navigationService;
        public MainPageViewModel(IRestaurantAppService restaurantAppService, ICustomNavigation navigationService)
        {
            this._restaurantAppService = restaurantAppService;
            this._navigationService = navigationService;
            
            LoadData();
        }

        public async Task LoadData()
        {
            Restaurants = await _restaurantAppService.GetRestaurants();
        }

        

        


        private List<Restaurant> _restaurants;

        public List<Restaurant> Restaurants
        {
            get { return _restaurants; }
            set
            {
                _restaurants = value;
                RaisePropertyChanged(()=>Restaurants);
            }
        }

        private Restaurant _restaurant;

        public Restaurant Restaurant
        {
            get { return _restaurant; }
            set
            {
                _restaurant = value;
                RaisePropertyChanged(()=>Restaurant);


                try
                {
                    _navigationService.NavigateTo(ServiceLocator.ReviewView, _restaurant);

                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception Message: " + ex.Message);
                }
            }
        }

        

        



    }
}
