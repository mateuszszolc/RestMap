using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RestMap.Helpers;
using RestMap.Model.Zomato;
using RestMap.Model.Zomato.Restaurant;
using RestMap.View;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace RestMap.ViewModel
{
    public class RestaurantDetailsViewModel
    {
        public RestaurantContainer RestaurantContainer { get; set; }

        public Command NavigateToPhotosPageCommand { get; set; }
        public Command NavigateToReviewsPageCommand { get; set; }
        public Command NavigateToMenuPageCommand { get; set; }
        public Command OpenPhoneDialerCommand { get; set; }
        public Command OpenGoogleMapsCommand { get; set; }
        public Command OpenBrowserCommand { get; set; }

        public RestaurantDetailsViewModel()
        {
            NavigateToPhotosPageCommand = new Command(async () => await NavigateToPhotosPage());
            NavigateToReviewsPageCommand = new Command(async () => await NavigateToReviewsPage());
            NavigateToMenuPageCommand =
                new Command<RestaurantContainer>(async (param) => await NavigateToMenuPage(param));
            OpenPhoneDialerCommand = new Command<RestaurantContainer>((param) => OpenPhoneDialer(param));
            OpenGoogleMapsCommand = new Command<RestaurantContainer>(async (param) => await OpenGoogleMaps(param));
            OpenBrowserCommand = new Command<RestaurantContainer>(async (param) => await OpenBrowser(param));
            RestaurantContainer = new RestaurantContainer();
        }

        public async Task AnimatePancakeView(PancakeView view)
        {
            view.TranslationY = 600;
            await view.TranslateTo(0, 0, 500, Easing.SinInOut);
        }

        public async Task GetRestaurantContainer(string id)
        {
            RestaurantContainer = await RestaurantDetailsService.GetRestaurantDetails(id);
            App.RestaurantsContainer = this.RestaurantContainer;
        }

        public async Task NavigateToPhotosPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new PhotosPage());
        }

        public async Task NavigateToReviewsPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new ReviewsPage());
        }

        public async Task NavigateToMenuPage(RestaurantContainer param)
        {
            await App.Current.MainPage.Navigation.PushAsync(new MenuPage(param));
        }

        public void OpenPhoneDialer(RestaurantContainer param)
        {
            try
            {
                PhoneDialer.Open(param.phone_numbers);
            }
            catch (ArgumentNullException argumentNullException)
            {
                MessageHelper.DisplayMessage("Error", $"Phone number is Empty. {argumentNullException.Message}", "Ok");
            }
            catch (FeatureNotSupportedException featureNotSupportedException)
            {
                MessageHelper.DisplayMessage("Error",
                    $"Phone dialer is not supported on this device. {featureNotSupportedException.Message}", "Ok");
            }
            catch (Exception exception)
            {
                MessageHelper.DisplayMessage("Error", $"An error occurred when trying open the Phone Dialer. {exception.Message}", "Ok");
            }
        }

        public async Task OpenGoogleMaps(RestaurantContainer param)
        {
            try
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    await Launcher.OpenAsync(string.Format("http://maps.google.com/?daddr={0}",
                        param.location.address));
                }
                else
                {
                    MessageHelper.DisplayMessage("Error", $"The platform is not supported", "Ok");
                }
            }
            catch (Exception exception)
            {
                MessageHelper.DisplayMessage("Error", $"An error occurred when trying open Google Maps. {exception.Message}", "Ok");
            
            }
        }

        public async Task OpenBrowser(RestaurantContainer param)
        {
            try
            {
                await Browser.OpenAsync(param.url);
            }
            catch (Exception exception)
            {
                MessageHelper.DisplayMessage("Error", $"An error occurred when trying open the Browser. {exception.Message}", "Ok");
                throw;
            }
        }
    }
}
