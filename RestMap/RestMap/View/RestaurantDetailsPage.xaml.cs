using RestMap.Model.Zomato;
using RestMap.Model.Zomato.Geocode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Android.Telecom;
using RestMap.Model.Zomato.Search;
using RestMap.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantDetailsPage : ContentPage
    {
        private readonly RestaurantDetailsViewModel _restaurantDetailsViewModel;
        private string _id;
        public RestaurantDetailsPage(string id)
        {
            InitializeComponent();
            _restaurantDetailsViewModel = new RestaurantDetailsViewModel();
            _id = id;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _restaurantDetailsViewModel.AnimatePancakeView(DetailsView);
            await _restaurantDetailsViewModel.GetRestaurantContainer(_id);
            _restaurantDetailsViewModel.CheckIfIsRestaurantFavourite();
            BindingContext = _restaurantDetailsViewModel;
        }

       

       
    }
}