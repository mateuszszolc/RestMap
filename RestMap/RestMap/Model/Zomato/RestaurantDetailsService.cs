using RestMap.Model.Zomato.API_Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestMap.Model.Zomato
{
    class RestaurantDetailsService
    {
        static ZomatoClient zomatoClient = new ZomatoClient();
        static ZomatoService zomatoService = new ZomatoService(zomatoClient);

        public static async Task<Model.Zomato.Restaurant.RestaurantContainer> GetRestaurantDetails(string id)
        {
            Model.Zomato.Restaurant.RestaurantContainer restaurantContainer = await zomatoService.GetRestaurantDetailsByIdAsync(id);

            if (restaurantContainer.FeaturedImage == string.Empty)
            {
                restaurantContainer.FeaturedImage = "defaultImage.png";
            }

            return restaurantContainer;
        }
    }
}
