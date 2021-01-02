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
using RestMap.Model.Zomato;
using RestMap.Model.Zomato.Geocode;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Position = Plugin.Geolocator.Abstractions.Position;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private bool hasLocationPermission = false;

        private List<NearbyRestaurant> nearbyRestaurant = new List<NearbyRestaurant>();

        public MapPage()
        {
            InitializeComponent();

            GetPermissions();

        }


        private async void GetPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);

                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("Need your location", "We need to access your location", "Ok");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (results.ContainsKey(Permission.LocationWhenInUse))
                    {
                        status = results[Permission.LocationWhenInUse];
                    }
                }

                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    LocationMap.IsShowingUser = true;

                    GetLocation();
                }
                else
                {
                    await DisplayAlert("Location denied", "You didn't get permission to the location", "Ok");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                locator.PositionChanged += Locator_PositionChanged;
                await locator.StartListeningAsync(TimeSpan.Zero, 100);
            }

            GetLocation();

            
           SetNearbyRestaurants();

            //DisplayPinsInMap(nearbyRestaurant);
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

                    LocationMap.Pins.Add(pin);
                }
                catch(NullReferenceException){}
                catch(Exception exception){}
            }
        }

        private async void Pin_Clicked(object sender, EventArgs e)
        {
            var selectedPin = sender as Pin;

            var selectedRestaurant = App.NearbyRestaurants.FirstOrDefault(x => !(selectedPin is null) && (x.Restaurant.Location.Address == selectedPin.Address) && (x.Restaurant.Name == selectedPin.Label));

            await Navigation.PushAsync(new RestaurantDetailsPage(selectedRestaurant.Restaurant.Id));
        }

        protected async override void OnDisappearing()
        {
            base.OnDisappearing();

            await CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Locator_PositionChanged;
        }

        private void Locator_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
            var span = new Xamarin.Forms.Maps.MapSpan(center, 1, 1);
            LocationMap.MoveToRegion(span);
        }

        private async void SetNearbyRestaurants()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                 App.NearbyRestaurants = await NearbyRestaurantsService.GetRestaurants(position.Latitude.ToString(CultureInfo.InvariantCulture),
                     position.Longitude.ToString(CultureInfo.InvariantCulture));

                // App.NearbyRestaurants = await NearbyRestaurantsService.GetRestaurants();

                 if (App.NearbyRestaurants.Count > 0)
                 {
                     DisplayPinsInMap(App.NearbyRestaurants);
                 }
                 else
                 {
                     await DisplayAlert("Info",
                         "There are currently no restaurants in your current location. Choose another city.", "Ok");
                     await Navigation.PushAsync(new NotFoundPage());
                 }
            }
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchPage());
        }
    }
}