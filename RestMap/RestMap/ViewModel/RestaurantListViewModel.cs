using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Search;
using RestMap.View;
using Xamarin.Forms;

namespace RestMap.ViewModel
{
    public class RestaurantListViewModel
    {
        public string LocationText { get; set; }
        public ObservableCollection<RestaurantContainer> Restaurants { get; set; }
        public Command NavigateToSearchPageCommand { get; set; }
        public Command NavigateToSettingsPageCommand { get; set; }

        private readonly ZomatoServiceWorker _serviceWorker;


        public RestaurantListViewModel()
        {
            LocationText = $"{App.LocationSuggestion.CityName}, {App.LocationSuggestion.CountryName}";
            Restaurants = new ObservableCollection<RestaurantContainer>();
            _serviceWorker = new ZomatoServiceWorker();
           NavigateToSearchPageCommand = new Command(async () => await NavigateToSearchPage());
           NavigateToSettingsPageCommand = new Command(async () => await NavigateToSettingsPage());
        }

        public async Task NavigateToSearchPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SearchPage());
        }

        public async Task NavigateToSettingsPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }


        public async void GetRestaurants()
        {
            if (App.LocationSuggestion != null)
            {
                var restaurants = await _serviceWorker.SearchRestaurantsAsync(App.LocationSuggestion.EntityId.ToString(),
                    App.LocationSuggestion.EntityType);

                if (restaurants.Count > 0)
                {
                    Restaurants.Clear();

                    foreach (var restaurant in restaurants)
                    {
                        Restaurants.Add(restaurant);
                    }
                }
            }
        }
    }
}
