using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato.Restaurant;

namespace RestMap.Model.Application
{
    public class FavouriteRestaurant : INotifyPropertyChanged
    {
        private string applicationUserId;

        public string ApplicationUserId
        {
            get => applicationUserId;
            set
            {
                applicationUserId = value;
                OnPropertyChanged(nameof(ApplicationUserId));
            }
        }

        private string id;

        public string Id
        {
            get => id;
            set
            {
                id = value; 
                OnPropertyChanged(nameof(Id));
            }
        }

        private string restaurantAddress;

        public string RestaurantAddress
        {
            get => restaurantAddress;
            set
            {
                restaurantAddress = value; 
                OnPropertyChanged(nameof(RestaurantAddress));
            }
        }

        private string restaurantName;

        public string RestaurantName
        {
            get => restaurantName;
            set
            {
                restaurantName = value; 
                OnPropertyChanged(RestaurantName);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static async Task InsertFavouriteRestaurant(RestaurantContainer restaurantContainer)
        {
            FavouriteRestaurant favouriteRestaurant = new FavouriteRestaurant()
            {
                ApplicationUserId = App.ApplicationUser.Id,
                Id = restaurantContainer.Id,
                RestaurantName = restaurantContainer.Name,
                RestaurantAddress = restaurantContainer.Location.Address
            };

            await App.MobileServiceClient.GetTable<FavouriteRestaurant>().InsertAsync(favouriteRestaurant);
        }

        public static async Task DeleteFavouriteRestaurant(RestaurantContainer restaurantContainer)
        {
            var favourites = await ReadFavouritesRestaurants();

            var restaurantToDelete = favourites.FirstOrDefault(x => x.Id == restaurantContainer.Id);
            await App.MobileServiceClient.GetTable<FavouriteRestaurant>().DeleteAsync(restaurantToDelete);
        }

        public static async Task<List<FavouriteRestaurant>> ReadFavouritesRestaurants()
        {
           var favourites =  await App.MobileServiceClient.GetTable<FavouriteRestaurant>()
                .Where(x => x.ApplicationUserId == App.ApplicationUser.Id).ToListAsync();

           return favourites;
        }
    }
}
