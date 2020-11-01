using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using RestMap.Model.Application;
using RestMap.Model.Zomato.Geocode;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap
{
    public partial class App : Application
    {
        public static List<NearbyRestaurant> NearbyRestaurants;

        public static MobileServiceClient MobileServiceClient = new MobileServiceClient("https://restmapapp.azurewebsites.net");

        public static ApplicationUser ApplicationUser = new ApplicationUser();
        public App()
        {
            InitializeComponent();
            NearbyRestaurants = new List<NearbyRestaurant>();
            MainPage = new NavigationPage(new View.LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
