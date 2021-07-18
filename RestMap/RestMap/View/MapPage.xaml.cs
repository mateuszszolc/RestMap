using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.Content;
using RestMap.Model.Zomato;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Geocode;
using RestMap.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Position = Plugin.Geolocator.Abstractions.Position;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private readonly MapViewModel _mapViewModel;

        public MapPage()
        {
            InitializeComponent();
            _mapViewModel = new MapViewModel(LocationMap);
            BindingContext = _mapViewModel;
            _mapViewModel.GetLocationPermission();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _mapViewModel.InitializeLocator();
            _mapViewModel.GetLocation();
            _mapViewModel.SetNearbyRestaurants();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            await _mapViewModel.StopLocatorWorking();
        }

    }
}