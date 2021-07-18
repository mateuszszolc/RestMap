using Plugin.SharedTransitions;
using System;
using System.Collections.Generic;
using FFImageLoading.Exceptions;
using Microsoft.WindowsAzure.MobileServices;
using RestMap.Model.Application;
using RestMap.Model.Zomato.Geocode;
using RestMap.Model.Zomato.Locations;
using RestMap.Model.Zomato.Search;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestaurantContainer = RestMap.Model.Zomato.Restaurant.RestaurantContainer;

namespace RestMap
{
    public partial class App : Application
    {
        public static List<NearbyRestaurant> NearbyRestaurants = new List<NearbyRestaurant>();

        public static MobileServiceClient MobileServiceClient = new MobileServiceClient("my_url");

        public static ApplicationUser ApplicationUser = new ApplicationUser();

        public static RestaurantContainer RestaurantsContainer = new RestaurantContainer();

        public static LocationSuggestion LocationSuggestion = new LocationSuggestion();

        public static SpecificRestaurant ChoosenRestaurant = new SpecificRestaurant();

        public static NearbyRestaurant NearbyRestaurant = new NearbyRestaurant();

        public App()
        {
            InitializeComponent();
            
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
