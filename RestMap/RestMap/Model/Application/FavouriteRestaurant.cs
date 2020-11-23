using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
    }
}
