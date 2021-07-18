using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using RestMap.Model.Application;
using Xamarin.Forms;

namespace RestMap.ViewModel
{
    public class UserImagesViewModel
    {
        public ObservableCollection<RestaurantImage> RestaurantImages { get; set; }

        public Command RemoveImageCommand
        {
            get
            {
                return new Command<RestaurantImage>((image) =>
                {
                    RestaurantImage.RemoveRestaurantImage(image);
                });
            }
        }

        public UserImagesViewModel()
        {
            RestaurantImages = new ObservableCollection<RestaurantImage>();
        }

        public async void GetUserRestaurantImages()
        {
            var images = await RestaurantImage.GetRestaurantImagesByUser();

            if (images != null)
            {
                RestaurantImages.Clear();

                foreach (var image in images)
                {
                    RestaurantImages.Add(image);
                }
            }
        }
    }
}
