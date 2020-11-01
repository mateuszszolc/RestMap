using RestMap.Model.Zomato;
using RestMap.Model.Zomato.Geocode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantDetailsPage : ContentPage
    {
        string _id;
        Model.Zomato.Restaurant.RestaurantContainer _resContainer;
        public RestaurantDetailsPage(string id)
        {
            InitializeComponent();
            _id = id;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            DetailsView.TranslationY = 600;
            await DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
            _resContainer = await RestaurantDetailsService.GetRestaurantDetails(_id);
            BindingContext = _resContainer;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //await DisplayAlert("Info", "Desc", "Cancel");
            try
            {
                PhoneDialer.Open(_resContainer.phone_numbers);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            if(Device.RuntimePlatform == Device.Android)
            {
                await Launcher.OpenAsync(string.Format("http://maps.google.com/?daddr={0}", _resContainer.location.address));
            }
            else
            {
                //Nieobsługiwana platforma 
            }
        }

        private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            await Browser.OpenAsync(_resContainer.url);
        }

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}