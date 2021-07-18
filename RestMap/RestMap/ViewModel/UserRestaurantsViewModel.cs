using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using RestMap.Model.Application;
using RestMap.View;
using Xamarin.Forms;

namespace RestMap.ViewModel
{
    public class UserRestaurantsViewModel
    {
        public ObservableCollection<FavouriteRestaurant> Restaurants { get; set; }

        public UserRestaurantsViewModel()
        {
            Restaurants = new ObservableCollection<FavouriteRestaurant>();
        }

        public Command NavigateToDetailsPage
        {
            get
            {
                return new Command<string>(async (id) => 
                {
                    await App.Current.MainPage.Navigation.PushAsync(new RestaurantDetailsPage(id));
                });
            }
        }

        public async void GetFavouriteRestaurantsByUser()
        {
            var restaurants = await FavouriteRestaurant.ReadFavouritesRestaurants();

            if (restaurants != null)
            {
                Restaurants.Clear();

                foreach (var restaurant in restaurants)
                {
                    Restaurants.Add(restaurant);
                }
            }
        }
    }
}
