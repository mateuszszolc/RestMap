using RestMap.Model.Zomato.Geocode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato.Daily_Menu;
using RestMap.Model.Zomato.Reviews;
using RestMap.Model.Zomato.Search;

namespace RestMap.Interfaces
{
    public interface IZomatoService
    {
        Task<LocationDetailsContainer> GetLocationDetailsByCoordinatesAsync(string lat = null, string lon = null);
        Task<Model.Zomato.Restaurant.RestaurantContainer> GetRestaurantDetailsByIdAsync(string id = null);
        Task<Model.Zomato.Locations.LocationSuggestionContainer> GetLocationSuggestionsAsync(string query = null);
        Task<RestaurantsContainer> GetRestaurantsByChoosenLocationAsync(string entityId = null, string entityType = null);
        Task<DailyMenusContainer> GetDailyMenusAsync(string id = null);
        Task<UserReviewsContainer> GetReviewsAsync(string id = null, string count = null);
    }
}
