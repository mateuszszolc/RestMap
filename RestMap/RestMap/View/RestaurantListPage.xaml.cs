using RestMap.Model.Zomato;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Geocode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Telecom;
using RestMap.Model.Zomato.Locations;
using RestMap.Model.Zomato.Search;
using RestMap.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantListPage : ContentPage
    {

        private readonly RestaurantListViewModel _restaurantListViewModel;
        public RestaurantListPage()
        {
            InitializeComponent();
            _restaurantListViewModel = new RestaurantListViewModel();
            BindingContext = _restaurantListViewModel;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _restaurantListViewModel.GetRestaurants();
        }

        private async void NavigateToSpecificRestaurantPage(object sender, EventArgs e)
         {
            var choosenRestaurant = ((sender as Xamarin.Forms.View).BindingContext as Model.Zomato.Search.RestaurantContainer).Restaurant;

            App.ChoosenRestaurant = choosenRestaurant;

            await Navigation.PushAsync(new RestaurantDetailsPage(App.ChoosenRestaurant.Id));
        }
    }
   
}