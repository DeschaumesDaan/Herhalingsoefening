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

        private string _error;

        public string Error
        {
            get { return _error; }
            set
            {
                _error = value;
                RaisePropertyChanged(()=>Error);
            }
        }


        private Review _review = new Review();

        public Review Review
        {
            get { return _review; }
            set
            {
                _review = value;
                RaisePropertyChanged(() => Review);

            }
        }


        private decimal[] _scoreNumbers = new decimal[] {1,2,3,4,5};

        public decimal[] ScoreNumbers
        {
            get { return _scoreNumbers; }
            set
            {
                _scoreNumbers = value;
                RaisePropertyChanged(()=>ScoreNumbers);
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
            }
        }


        private void SendData()
        {
            if (Review.Score == 0 || string.IsNullOrEmpty(Review.UserName))
            {
                Error = "Gelieve jouw naam en een score in te vullen!";

            }
            else
            {
                _restaurantAppService.AddReview(_restaurant.Id.ToString(), Review);
                _navigationService.GoBack();
            }
        }


        public RelayCommand SaveReviewCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    SendData();
                    
                });
            }
        }

    






    }
}
