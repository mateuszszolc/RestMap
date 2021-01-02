using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RestMap.Helpers;
using RestMap.Model.Application;
using RestMap.Model.Zomato;
using RestMap.Model.Zomato.Restaurant;
using RestMap.View;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;

namespace RestMap.ViewModel
{
    public class RestaurantDetailsViewModel : INotifyPropertyChanged
    {
        public RestaurantContainer RestaurantContainer { get; set; }

        public Command NavigateToPhotosPageCommand { get; set; }
        public Command NavigateToReviewsPageCommand { get; set; }
        public Command NavigateToMenuPageCommand { get; set; }
        public Command OpenPhoneDialerCommand { get; set; }
        public Command OpenGoogleMapsCommand { get; set; }
        public Command OpenBrowserCommand { get; set; }
        public Command SetFavouriteRestaurantCommand { get; set; }

        private bool isRestaurantFavourite;

        public bool IsRestaurantFavourite
        {
            get => isRestaurantFavourite;
            set
            {
                isRestaurantFavourite = value;
                OnPropertyChanged(nameof(IsRestaurantFavourite));
            }
        }

        public RestaurantDetailsViewModel()
        {
            NavigateToPhotosPageCommand = new Command(async () => await NavigateToPhotosPage());
            NavigateToReviewsPageCommand = new Command(async () => await NavigateToReviewsPage());
            NavigateToMenuPageCommand =
                new Command<RestaurantContainer>(async (param) => await NavigateToMenuPage(param));
            OpenPhoneDialerCommand = new Command<RestaurantContainer>((param) => OpenPhoneDialer(param));
            OpenGoogleMapsCommand = new Command<RestaurantContainer>(async (param) => await OpenGoogleMaps(param));
            OpenBrowserCommand = new Command<RestaurantContainer>(async (param) => await OpenBrowser(param));
            SetFavouriteRestaurantCommand = new Command<RestaurantContainer>(async (param) => await SetFavouriteRestaurant(param));
            RestaurantContainer = new RestaurantContainer();
           // CheckIfIsRestaurantFavourite();
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
        public async void CheckIfIsRestaurantFavourite()
        {
            var favouriteRestaurants = await FavouriteRestaurant.ReadFavouritesRestaurants();

            if (favouriteRestaurants.Any(x =>
                x.Id == RestaurantContainer.Id))
            {
                this.IsRestaurantFavourite = true;
            }
            else
            {
                this.IsRestaurantFavourite = false;
            }
        }

        public async Task SetFavouriteRestaurant(RestaurantContainer param)
        {
            if (IsRestaurantFavourite)
            {
                await FavouriteRestaurant.DeleteFavouriteRestaurant(param);
                this.IsRestaurantFavourite = false;
                MessageHelper.DisplayMessage("Information", "Restaurant was deleted from favourites.", "Ok");
            }
            else
            {
                await FavouriteRestaurant.InsertFavouriteRestaurant(param);
                this.IsRestaurantFavourite = true;
                MessageHelper.DisplayMessage("Information", "Restaurant was added from favourites.", "Ok");
            }
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
                PhoneDialer.Open(param.PhoneNumbers);
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
                        param.Location.Address));
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
                await Browser.OpenAsync(param.Url);
            }
            catch (Exception exception)
            {
                MessageHelper.DisplayMessage("Error", $"An error occurred when trying open the Browser. {exception.Message}", "Ok");
                throw;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
