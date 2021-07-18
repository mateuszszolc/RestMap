using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content.Res;
using Plugin.Geolocator;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using RestMap.Helpers;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Geocode;
using RestMap.View;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace RestMap.ViewModel
{
    public class MapViewModel
    {
        private readonly ZomatoServiceWorker _serviceWorker;

        public bool HasLocationPermission { get; set; } = false;
        public Command NavigateToSearchPageCommand { get; set; }
        public List<NearbyRestaurant> NearbyRestaurants { get; set; }
        public Map Map { get; set; }

        public MapViewModel(Map map)
        {
            Map = map;
            NearbyRestaurants = new List<NearbyRestaurant>();
            _serviceWorker = new ZomatoServiceWorker();
            NavigateToSearchPageCommand = new Command(async () => await NavigateToSearchPage());
        }

        public async void GetLocationPermission()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);

                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        MessageHelper.DisplayMessage("Need your location", "We need to access your location", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                    {
                        status = results[Permission.LocationWhenInUse];
                    }
                }

                if (status == PermissionStatus.Granted)
                {
                    HasLocationPermission = true;
                    Map.IsShowingUser = true;

                    GetLocation();
                }
                else
                {
                    MessageHelper.DisplayMessage("Location denied", "You didn't get permission to the location", "Ok");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.DisplayMessage("Error", ex.Message, "Ok");
            }
        }

        public async Task InitializeLocator()
        {
            if (HasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }
        }

        public async Task StopLocatorWorking()
        {
            await CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        public async void SetNearbyRestaurants()
        {
            if (HasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                NearbyRestaurants = await _serviceWorker
                    .GetRestaurantsAsync(position.Latitude.ToString(CultureInfo.InvariantCulture), position.Longitude.ToString(CultureInfo.InvariantCulture));


               App.NearbyRestaurants = NearbyRestaurants;

                if (App.NearbyRestaurants.Count > 0)
                {
                    DisplayPinsInMap(App.NearbyRestaurants);
                }
                else
                {
                    MessageHelper.DisplayMessage("Info",
                        "There are currently no restaurants in your current location. Choose another city.", "Ok");
                    await App.Current.MainPage.Navigation.PushAsync(new NotFoundPage());
                }
            }
        }

        public async void GetLocation()
        {
            if (HasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }


        private void MoveMap(Plugin.Geolocator.Abstractions.Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            Map.MoveToRegion(span);
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void Pin_Clicked(object sender, EventArgs e)
        {
            var selectedPin = sender as Pin;

            var selectedRestaurant = App.NearbyRestaurants.FirstOrDefault(x => !(selectedPin is null) && (x.Restaurant.Location.Address == selectedPin.Address) && (x.Restaurant.Name == selectedPin.Label));

            App.NearbyRestaurant = selectedRestaurant;

            await App.Current.MainPage.Navigation.PushAsync(new RestaurantDetailsPage(App.NearbyRestaurant.Restaurant.Id));
        }

        private void DisplayPinsInMap(List<NearbyRestaurant> restaurants)
        {
            foreach (var item in restaurants)
            {
                try
                {
                    double longitude = Convert.ToDouble(item.Restaurant.Location.Longitude.Replace(".", ","));
                    double latitude = Convert.ToDouble(item.Restaurant.Location.Latitude.Replace(".", ","));
                    var position =
                        new Xamarin.Forms.Maps.Position(latitude, longitude);

                    var pin = new Xamarin.Forms.Maps.Pin()
                    {
                        Type = Xamarin.Forms.Maps.PinType.SavedPin,
                        Position = position,
                        Label = item.Restaurant.Name,
                        Address = item.Restaurant.Location.Address

                    };

                    pin.Clicked += Pin_Clicked;

                    Map.Pins.Add(pin);
                }
                catch (NullReferenceException) { }
                catch (Exception exception) { }
            }
        }



        public async Task NavigateToSearchPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SearchPage());
        }
    }
}
