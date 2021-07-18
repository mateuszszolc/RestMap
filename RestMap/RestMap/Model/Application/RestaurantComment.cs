using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato.Geocode;

namespace RestMap.Model.Application
{
    public class RestaurantComment : INotifyPropertyChanged
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

        private string commentContent;

        public string CommentContent
        {
            get => commentContent;
            set
            {
                commentContent = value;
                OnPropertyChanged(nameof(CommentContent));
            }
        }

        public static async void InsertRestaurantComment(RestaurantComment restaurantComment)
        {
            restaurantComment.ApplicationUserId = App.ApplicationUser.Id;
            restaurantComment.RestaurantId = App.RestaurantsContainer.Id;
            await App.MobileServiceClient.GetTable<RestaurantComment>().InsertAsync(restaurantComment);
        }

        public static async Task<List<RestaurantComment>> GetRestaurantComments()
        {
            return await App.MobileServiceClient.GetTable<RestaurantComment>()
                .Where(x => (x.RestaurantId == App.RestaurantsContainer.Id))
                .ToListAsync();
        }

        public static async Task<List<RestaurantComment>> GetRestaurantCommentsByUser()
        {
            return await App.MobileServiceClient.GetTable<RestaurantComment>()
                .Where(x => (x.ApplicationUserId == App.ApplicationUser.Id))
                .ToListAsync();
        }

        public static async void RemoveRestaurantComment(RestaurantComment comment)
        {
            await App.MobileServiceClient.GetTable<RestaurantComment>().DeleteAsync(comment);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
