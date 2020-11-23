using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using RestMap.Model.Application;
using RestMap.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotosPage : ContentPage
    {
        private PhotosViewModel photosViewModel;

        public PhotosPage()
        {
            InitializeComponent();
            photosViewModel = new PhotosViewModel();
            BindingContext = photosViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            photosViewModel.GetRestaurantImages();
        }

        //Komenda
        private async void SelectImage_OnClicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Info", "Not supported", "Ok");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync();

            if (selectedImageFile == null)
            {
                await DisplayAlert("Info", "An error occurred when trying to add image", "Ok");
                return;
            }

            //SelectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
            //CachedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
            
            UploadImage(selectedImageFile.GetStream());
            
        }

        private async void UploadImage(Stream stream)
        {
            var account = CloudStorageAccount.Parse(
                "DefaultEndpointsProtocol=https;AccountName=restmapimagestorage;AccountKey=E5bpfOf9d03VjORfFPvTjF8tWfAciCVe52Y3bUWoue+VstkvIMEOZFVZhPPMrKikkeLf0cbo6WcJDXgYF+/UaQ==;EndpointSuffix=core.windows.net");

            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("restmapimagecontainer");
            await container.CreateIfNotExistsAsync();

            var imageName = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{imageName}.jpg");
            await blockBlob.UploadFromStreamAsync(stream);

            var imageUrl = blockBlob.Uri.OriginalString;

            RestaurantImage.AddRestaurantImage(imageUrl);

        }

        private async void ShowMorePhotos_Clicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync(photosViewModel.RestaurantContainer.photos_url);
        }
    }
}