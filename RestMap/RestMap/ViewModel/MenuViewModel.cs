using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using RestMap.Model;
using RestMap.Model.Zomato.Daily_Menu;
using RestMap.Model.Zomato.Restaurant;

namespace RestMap.ViewModel
{
    public class MenuViewModel
    {
        public RestaurantContainer RestaurantContainer { get; set; }
        public ObservableCollection<DailyMenuContainer>  DailyMenuContainer { get; set; }

        public MenuViewModel()
        {
            RestaurantContainer = new RestaurantContainer();
            DailyMenuContainer = new ObservableCollection<DailyMenuContainer>();
            if (App.RestaurantsContainer != null)
            { 
                RestaurantContainer = App.RestaurantsContainer;
            }
        }

        public async void GetDailyMenus()
        {
            if (App.RestaurantsContainer != null)
            {
                var dailyMenus = await DailyMenuService.GetDailyMenus(App.RestaurantsContainer.id);
               // var dailyMenus = await DailyMenuService.GetDailyMenus("16507624");

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
