using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using RestMap.Helpers;
using RestMap.Model;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Daily_Menu;
using RestMap.Model.Zomato.Restaurant;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RestMap.ViewModel
{
    public class MenuViewModel
    {
        public RestaurantContainer RestaurantContainer { get; set; }
        public ObservableCollection<DailyMenuContainer>  DailyMenuContainer { get; set; }
        public Command OpenMenuPageCommand { get; set; }

        private readonly ZomatoServiceWorker _serviceWorker;

        public MenuViewModel()
        {
            OpenMenuPageCommand = new Command<RestaurantContainer>(async (param) => await OpenMenuPage(param));
            RestaurantContainer = new RestaurantContainer();
            DailyMenuContainer = new ObservableCollection<DailyMenuContainer>();
            _serviceWorker = new ZomatoServiceWorker();

            if (App.RestaurantsContainer != null)
            { 
                RestaurantContainer = App.RestaurantsContainer;
            }
        }

        public async Task OpenMenuPage(RestaurantContainer restaurantContainer)
        {
            try
            {
                await Browser.OpenAsync(restaurantContainer.MenuUrl);
            }
            catch (Exception ex)
            {
                MessageHelper.DisplayMessage($"Error", $"Cannot open menu page. {ex.Message}", "Ok");
                throw;
            }
        }

        public async void GetDailyMenus()
        {
            if (App.RestaurantsContainer != null)
            {
                var dailyMenus = await _serviceWorker.GetDailyMenusAsync(App.RestaurantsContainer.Id);

                if (dailyMenus != null)
                {
                    DailyMenuContainer.Clear();

                    foreach (var dailyMenu in dailyMenus)
                    {
                        DailyMenuContainer.Add(dailyMenu);
                    }
                }
            }
        }
    }
}
