using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Android.Provider;
using Microsoft.WindowsAzure.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RestMap.Helpers;
using RestMap.Model.Application;
using RestMap.Model.Zomato.Restaurant;
using RestMap.Settings;
using Xamarin.Forms;
using Browser = Xamarin.Essentials.Browser;

namespace RestMap.ViewModel
{
    public class PhotosViewModel
    {
        public RestaurantContainer RestaurantContainer { get; set; }
        public ObservableCollection<RestaurantImage> RestaurantImages { get; set; }
        public Command SelectImageCommand { get; set; }
        public Command OpenPhotosPageCommand { get; set; }
        private readonly Action _refreshMethod;

        public PhotosViewModel(Action refreshMethod)
        {
            _refreshMethod = refreshMethod;
            RestaurantContainer = new RestaurantContainer();
            RestaurantImages = new ObservableCollection<RestaurantImage>();
            SelectImageCommand = new Command(() => SelectImage());
            OpenPhotosPageCommand = new Command<RestaurantContainer>(async (param) => await OpenPhotosPage(param));
            if (App.RestaurantsContainer != null)
            {
                RestaurantContainer = App.RestaurantsContainer;
            }
        }

        public async Task OpenPhotosPage(RestaurantContainer restaurantContainer)
        {
            await Browser.OpenAsync(restaurantContainer.PhotosUrl);
        }

        public async void SelectImage()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                MessageHelper.DisplayMessage("Info", "Not supported", "Ok");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync();

            if (selectedImageFile == null)
            {
                MessageHelper.DisplayMessage("Info", "An error occurred when trying to add image", "Ok");
                return;
            }

            UploadImage(selectedImageFile.GetStream());
        }

        private async void UploadImage(Stream stream)
        {
            var account = CloudStorageAccount.Parse(AzureSettings.AZURE_STORAGE_ACCOUNT);

            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(AzureSettings.AZURE_STORAGE_CONTAINER);
            await container.CreateIfNotExistsAsync();

            var imageName = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{imageName}.jpg");
            await blockBlob.UploadFromStreamAsync(stream);

            var imageUrl = blockBlob.Uri.OriginalString;

            await RestaurantImage.AddRestaurantImage(imageUrl);

            this._refreshMethod();
        }

        public async void GetRestaurantImages()
        {
            if (App.ApplicationUser != null && App.RestaurantsContainer != null)
            {
                var restaurantImages = await RestaurantImage.GetRestaurantImages();

                if (restaurantImages != null)
                {
                    RestaurantImages.Clear();

                    foreach (var image in restaurantImages)
                    {
                        RestaurantImages.Add(image);
                    }
                }
            }
        }

    }
}
