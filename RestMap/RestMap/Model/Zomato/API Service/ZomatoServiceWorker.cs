using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato.Daily_Menu;
using RestMap.Model.Zomato.Geocode;
using RestMap.Model.Zomato.Locations;
using RestMap.Model.Zomato.Reviews;
using RestMap.Model.Zomato.Search;
using RestaurantContainer = RestMap.Model.Zomato.Geocode.RestaurantContainer;

namespace RestMap.Model.Zomato.API_Service
{
    public class ZomatoServiceWorker
    {
        private readonly ZomatoClient _zomatoClient;
        private readonly ZomatoService _zomatoService;

        public ZomatoServiceWorker()
        {
            _zomatoClient = new ZomatoClient();
            _zomatoService = new ZomatoService(_zomatoClient);
        }

        public async Task<List<UserReview>> GetReviewsAsync(string id, string count)
        {
            var userReviewsContainer = await _zomatoService.GetReviewsAsync(id, count);

            if (userReviewsContainer != null)
            {
                return userReviewsContainer.UserReviews;
            }

            return null;
        }

        public async Task<List<DailyMenuContainer>> GetDailyMenusAsync(string id)
        {
            var dailyMenusContainer = await _zomatoService.GetDailyMenusAsync(id);

            if (dailyMenusContainer != null)
            {
                return dailyMenusContainer.DailyMenus;
            }

            return null;
        }

        public async Task<List<LocationSuggestion>> GetLocationSuggestionsAsync(string query)
        {
            LocationSuggestionContainer locationSuggestionContainer = await _zomatoService.GetLocationSuggestionsAsync(query);

            if (locationSuggestionContainer != null)
            {
                return locationSuggestionContainer.LocationSuggestions;
            }

            return null;
        }

        public async Task<List<NearbyRestaurant>> GetRestaurantsAsync(string latitude, string longitude)
        {
            LocationDetailsContainer locationDetailsContainer = await _zomatoService.GetLocationDetailsByCoordinatesAsync(latitude, longitude);

            if (locationDetailsContainer != null)
            {
                return locationDetailsContainer.NearbyRestaurants;
            }

            return new List<NearbyRestaurant>();
        }

        public async Task<Model.Zomato.Restaurant.RestaurantContainer> GetRestaurantDetailsAsync(string id)
        {
            Model.Zomato.Restaurant.RestaurantContainer restaurantContainer = await _zomatoService.GetRestaurantDetailsByIdAsync(id);

            if (restaurantContainer != null)
            {
                if (restaurantContainer.FeaturedImage == string.Empty)
                {
                    restaurantContainer.FeaturedImage = "defaultImage.png";
                }

                return restaurantContainer;
            }

            return null;
        }

        public async Task<List<Model.Zomato.Search.RestaurantContainer>> SearchRestaurantsAsync(string entityId, string entityType)
        {
            Model.Zomato.Search.RestaurantsContainer restaurantsContainer = await _zomatoService.GetRestaurantsByChoosenLocationAsync(entityId, entityType);

            if (restaurantsContainer != null)
            {
                foreach (var restaurant in restaurantsContainer.Restaurants)
                {
                    if (restaurant.Restaurant.FeaturedImage == string.Empty)
                    {
                        restaurant.Restaurant.FeaturedImage = "defaultImage.png";
                    }
                }

                return restaurantsContainer.Restaurants;
            }

            return null;
        }
    }
}
