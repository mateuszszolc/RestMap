using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        Model.Zomato.Restaurant.RestaurantContainer _resContainer;
        private MenuViewModel menuViewModel;

        public MenuPage(Model.Zomato.Restaurant.RestaurantContainer _resContainer)
        {
            InitializeComponent();
            this._resContainer = _resContainer;
            menuViewModel = new MenuViewModel();
           
            BindingContext = menuViewModel;

        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();

            menuViewModel.GetDailyMenus();
        }

        private async void ShowMenu_OnClicked(object sender, EventArgs e)
        {
            await Browser.OpenAsync(menuViewModel.RestaurantContainer.menu_url);
        }
    }
}