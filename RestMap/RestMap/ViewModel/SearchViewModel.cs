using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Org.Apache.Http.Impl.Client;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Locations;
using RestMap.View;

namespace RestMap.ViewModel
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private readonly ZomatoServiceWorker _zomatoServiceWorker;

        private List<LocationSuggestion> locationSuggestions;

        public List<LocationSuggestion> LocationSuggestions
        {
            get => locationSuggestions;
            set
            {
                locationSuggestions = value;
                OnPropertyChanged(nameof(LocationSuggestions));
            }
        }

        private LocationSuggestion locationSuggestion;

        public LocationSuggestion LocationSuggestion
        {
            get => locationSuggestion;
            set
            {
                locationSuggestion = value;
                OnPropertyChanged(nameof(LocationSuggestion));
                var location = LocationSuggestion;
                if (location.CityId != 0)
                {
                    App.LocationSuggestion = LocationSuggestion;
                }
                if (LocationSuggestion.CityId != 0)
                {
                    NavigateToRestaurantListPage();
                }
            }
        }

        private async void NavigateToRestaurantListPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RestaurantListPage());
        }


        private string searchText;

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                Task.Run(async () =>
                {
                    LocationSuggestions = await _zomatoServiceWorker.GetLocationSuggestionsAsync(searchText);
                });
            }
        }


        public SearchViewModel()
        {
            locationSuggestions = new List<LocationSuggestion>();
            locationSuggestion = new LocationSuggestion();
            _zomatoServiceWorker = new ZomatoServiceWorker();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
