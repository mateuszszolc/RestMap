using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Geocode;
using RestMap.Model.Zomato.Search;
using RestaurantContainer = RestMap.Model.Zomato.Search.RestaurantContainer;

namespace RestMap.Model.Zomato
{
    public static class SearchService
    {
        static ZomatoClient zomatoClient = new ZomatoClient();
        static ZomatoService zomatoService = new ZomatoService(zomatoClient);

        public static async Task<List<RestaurantContainer>> SearchRestaurantsAsync(string entityId, string entityType)
        {
            RestaurantsContainer restaurantsContainer =  await zomatoService.GetRestaurantsByChoosenLocationAsync(entityId, entityType);

            foreach (var restaurant in restaurantsContainer.Restaurants)
            {
                if (restaurant.Restaurant.FeaturedImage == string.Empty)
                {
                    restaurant.Restaurant.FeaturedImage = "defaultImage.png";
                }
            }

            return restaurantsContainer.Restaurants;
        }
    }
}
