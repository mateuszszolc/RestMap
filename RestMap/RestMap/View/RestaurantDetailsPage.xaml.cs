using RestMap.Model.Zomato;
using RestMap.Model.Zomato.Geocode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RestMap.ViewModel;
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

        private readonly RestaurantDetailsViewModel _restaurantDetailsViewModel;

        public RestaurantDetailsPage(string id)
        {
            InitializeComponent();
            _id = id;
            _restaurantDetailsViewModel = new RestaurantDetailsViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _restaurantDetailsViewModel.AnimatePancakeView(DetailsView);
            await _restaurantDetailsViewModel.GetRestaurantContainer(_id);
            _restaurantDetailsViewModel.CheckIfIsRestaurantFavourite();
            BindingContext = _restaurantDetailsViewModel;

            // DetailsView.TranslationY = 600;
            // await DetailsView.TranslateTo(0, 0, 500, Easing.SinInOut);
            // _resContainer = await RestaurantDetailsService.GetRestaurantDetails(_id);
            // App.RestaurantsContainer = _resContainer;
            //BindingContext = _resContainer;


        }

       

       
    }
}