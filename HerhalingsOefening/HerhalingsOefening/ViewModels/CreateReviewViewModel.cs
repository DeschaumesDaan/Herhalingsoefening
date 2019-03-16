using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HerhalingsOefening.Models;
using HerhalingsOefening.Services;
using OnBoardingOefening.Services;

namespace HerhalingsOefening.ViewModels
{
    public class CreateReviewViewModel:ViewModelBase
    {
        private readonly ICustomNavigation _navigationService;
        private readonly IRestaurantAppService _restaurantAppService;
        public CreateReviewViewModel(ICustomNavigation navigationService, IRestaurantAppService restaurantAppService)
        {
            this._navigationService = navigationService;
            this._restaurantAppService = restaurantAppService;
        }

        private int[] _scoreNumbers = new int[] {1,2,3,4,5};

        public int[] ScoreNumbers
        {
            get { return _scoreNumbers; }
            set { _scoreNumbers = value; }
        }




        private Restaurant _restaurant;

        public Restaurant Restaurant
        {
            get { return _restaurant; }
            set
            {
                _restaurant = value;
                RaisePropertyChanged(()=>Restaurant);
            }
        }

        private Review _review;

        public Review Review
        {
            get { return _review; }
            set
            {
                _review = value;
                RaisePropertyChanged(()=>Review);
                
            }
        }


        public RelayCommand SaveReviewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    try
                    {
                        _restaurantAppService.AddReview(_restaurant.Id.ToString(), Review);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Exception Message: " + ex.Message);
                        throw;
                    }
                    _navigationService.GoBack();
                });
            }
        }

    






    }
}
