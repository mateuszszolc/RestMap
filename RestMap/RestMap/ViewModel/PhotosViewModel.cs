using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using RestMap.Model.Application;
using RestMap.Model.Zomato.Restaurant;

namespace RestMap.ViewModel
{
    public class PhotosViewModel
    {
        public RestaurantContainer RestaurantContainer { get; set; }
        public ObservableCollection<RestaurantImage> RestaurantImages { get; set; }

        public PhotosViewModel()
        {
            RestaurantContainer = new RestaurantContainer();
            RestaurantImages = new ObservableCollection<RestaurantImage>();

            if (App.RestaurantsContainer != null)
            {
                RestaurantContainer = App.RestaurantsContainer;
            }
        }

        public async void GetRestaurantImages()
        {
            if (App.ApplicationUser != null && App.RestaurantsContainer != null)
            {
                var restaurantImages = await RestaurantImage.GetRestaurantImages();

                if (restaurantImages != null)
                {
                    RestaurantImages.Clear();

                    foreach (var image in restaurantImages)
                    {
                        RestaurantImages.Add(image);
                    }
                }
            }
        }

    }
}
