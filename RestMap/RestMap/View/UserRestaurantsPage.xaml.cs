using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Application;
using RestMap.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRestaurantsPage : ContentPage
    {
        private readonly UserRestaurantsViewModel _userRestaurantsViewModel;
        public UserRestaurantsPage()
        {
            InitializeComponent();
            _userRestaurantsViewModel = new UserRestaurantsViewModel();
            BindingContext = _userRestaurantsViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _userRestaurantsViewModel.GetFavouriteRestaurantsByUser();
        }

        private void SeeDetailsBtnClick(object sender, EventArgs e)
        {
            var button = sender as Button;

            var restaurant = button?.BindingContext as FavouriteRestaurant;

            var viewModel = BindingContext as UserRestaurantsViewModel;

            viewModel.NavigateToDetailsPage.Execute(restaurant.Id);
        }
    }
}