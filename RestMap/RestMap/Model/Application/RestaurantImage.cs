using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestMap.Model.Zomato.Restaurant;

namespace RestMap.Model.Application
{
    public class RestaurantImage : INotifyPropertyChanged
    {
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

        private string restaurantId;

        public string RestaurantId
        {
            get => restaurantId;
            set
            {
                restaurantId = value; 
                OnPropertyChanged(nameof(RestaurantId));
            }
        }

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

        private string imageUrl;

        public string ImageUrl
        {
            get => imageUrl;
            set
            {
                imageUrl = value;
                OnPropertyChanged(nameof(ImageUrl));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static async Task AddRestaurantImage(string url)
        {
            RestaurantImage restaurantImage = new RestaurantImage()
            {
                ApplicationUserId = App.ApplicationUser.Id,
                RestaurantId = App.RestaurantsContainer.Id,
                ImageUrl = url
            };

            await App.MobileServiceClient.GetTable<RestaurantImage>().InsertAsync(restaurantImage);
        }

        public static async Task<List<RestaurantImage>> GetRestaurantImages()
        {
            return await App.MobileServiceClient.GetTable<RestaurantImage>()
                .Where(x => (x.RestaurantId == App.RestaurantsContainer.Id))
                .ToListAsync();
        }

        public static async Task<List<RestaurantImage>> GetRestaurantImagesByUser()
        {
            return await App.MobileServiceClient.GetTable<RestaurantImage>()
                .Where(x => (x.ApplicationUserId == App.ApplicationUser.Id))
                .ToListAsync();
        }

        public static async void RemoveRestaurantImage(RestaurantImage image)
        {
            await App.MobileServiceClient.GetTable<RestaurantImage>().DeleteAsync(image);
        }
    }
}
