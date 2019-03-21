using System;
using GalaSoft.MvvmLight.Ioc;
using HerhalingsOefening.ViewModels;
using HerhalingsOefening.Views;
using OnBoardingOefening.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SettingsView = HerhalingsOefening.Views.SettingsView;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HerhalingsOefening
{
    public partial class App : Application
    {
        private static ServiceLocator _locator;
        public static ServiceLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ServiceLocator());
            }

        }
        public App()
        {
            InitializeComponent();
            var nav = new NavigationService();
            nav.Configure(ServiceLocator.MainPage, typeof(MainPage));
            nav.Configure(ServiceLocator.ReviewView, typeof(ReviewView));
            nav.Configure(ServiceLocator.CreateReview, typeof(CreateReview));
            nav.Configure(ServiceLocator.SettingsView, typeof(SettingsView));
            //configure other navs here!

            SimpleIoc.Default.Register<ICustomNavigation>(()=>nav);

            var mainPage = new NavigationPage(new MainPage());
            nav.Initialize(mainPage);
            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
