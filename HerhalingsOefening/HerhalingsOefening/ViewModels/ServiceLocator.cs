using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using HerhalingsOefening.Models;
using HerhalingsOefening.Repositories;
using HerhalingsOefening.Services;

namespace HerhalingsOefening.ViewModels
{
    public class ServiceLocator
    {
        public const string MainPage = "MainPage";
        public const string ReviewView = "ReviewView";
        public const string CreateReview = "CreateReview";
        public const string SettingsView = "SettingsView";


        public ServiceLocator()
        {
            SimpleIoc.Default.Register<IRestaurantRepository, RestaurantRepository>();
            SimpleIoc.Default.Register<IRestaurantAppService, RestaurantAppService>();
            SimpleIoc.Default.Register<IReviewRepository, ReviewRepository>();

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<ReviewViewModel>();
            SimpleIoc.Default.Register<CreateReviewViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainPageViewModel>();
            }
        }

        public ReviewViewModel ReviewViewModel
        {
            get
            {
                return SimpleIoc.Default.GetInstance<ReviewViewModel>();
            }
        }

        public CreateReviewViewModel CreateReviewViewModel
        {
            get { return SimpleIoc.Default.GetInstance<CreateReviewViewModel>(); }
        }

        public SettingsViewModel SettingsViewModel
        {
            get { return SimpleIoc.Default.GetInstance<SettingsViewModel>(); }
        }
    }
}
