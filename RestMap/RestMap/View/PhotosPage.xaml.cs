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
        private readonly PhotosViewModel _photosViewModel;

        public PhotosPage()
        {
            InitializeComponent();
            _photosViewModel = new PhotosViewModel(OnAppearing);
            BindingContext = _photosViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _photosViewModel.GetRestaurantImages();
        }
    }
}