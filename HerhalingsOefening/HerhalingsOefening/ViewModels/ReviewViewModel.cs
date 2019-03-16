using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HerhalingsOefening.Models;
using HerhalingsOefening.Repositories;
using HerhalingsOefening.Services;
using OnBoardingOefening.Services;

namespace HerhalingsOefening.ViewModels
{
    public class ReviewViewModel:ViewModelBase
    {


        private readonly IRestaurantAppService _restaurantAppService;
        private readonly ICustomNavigation _navigationService;
        public ReviewViewModel(IRestaurantAppService restaurantAppService, ICustomNavigation navigationService)
        {
            this._restaurantAppService = restaurantAppService;
            this._navigationService = navigationService;
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
                    LoadReviews(_restaurant).GetAwaiter();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Exception Message: " + ex.Message);
                }
            }
        }

        private List<Review> _reviews;

        public List<Review> Reviews
        {
            get { return _reviews; }
            set
            {
                _reviews = value;
                RaisePropertyChanged(() => Reviews);
            }
        }

        public async Task LoadReviews(Restaurant restaurant)
        {
            Reviews = await _restaurantAppService.GetReviews(restaurant.Id.ToString());
        }

        public RelayCommand MakeReviewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.NavigateTo(ServiceLocator.CreateReview, _restaurant);
                });
            }
        }











    }
}
