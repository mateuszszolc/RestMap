using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Geocode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestMap.Model.Zomato
{
    public static class NearbyRestaurantsService
    {
        static ZomatoClient zomatoClient = new ZomatoClient();
        static ZomatoService zomatoService = new ZomatoService(zomatoClient);

        public static async Task<List<NearbyRestaurant>> GetRestaurants()
        {
            LocationDetailsContainer locationDetailsContainer = await zomatoService.GetLocationDetailsByCoordinatesAsync("52.237049", "21.017532");

            return locationDetailsContainer.NearbyRestaurants;
        }

        public static async Task<List<NearbyRestaurant>> GetRestaurants(string latitude, string longitude)
        {
            LocationDetailsContainer locationDetailsContainer = await zomatoService.GetLocationDetailsByCoordinatesAsync(latitude, longitude);

            if (locationDetailsContainer == null)
            {
                return new List<NearbyRestaurant>();
            }

            return locationDetailsContainer.NearbyRestaurants;
        }
    }
}
