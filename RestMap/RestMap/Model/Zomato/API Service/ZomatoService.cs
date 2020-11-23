using RestMap.Interfaces;
using RestMap.Model.Zomato.Category;
using RestMap.Model.Zomato.Cities;
using RestMap.Model.Zomato.Collections;
using RestMap.Model.Zomato.Cuisines;
using RestMap.Model.Zomato.Daily_Menu;
using RestMap.Model.Zomato.Establishments;
using RestMap.Model.Zomato.Geocode;
using RestMap.Model.Zomato.Locations;
using RestMap.Model.Zomato.Reviews;
using RestMap.Model.Zomato.Search;
using RestMap.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestMap.Model.Zomato.API_Service
{
    public class ZomatoService : IZomatoService
    {
        private readonly IZomatoClient _zomatoClient;

        public ZomatoService(IZomatoClient zomatoClient)
        {
            _zomatoClient = zomatoClient;
        }
        public async Task<CategoriesContainer> GetCategoriesAsync()
        {
            return await _zomatoClient.GetAsync<CategoriesContainer>(ZomatoSettings.CATEGORY_ENDPOINT);
        }

        public async Task<LocationSuggestions> GetCitiesByCoordinatesAsync(string lat = null, string lon = null)
        {
            return await _zomatoClient.GetAsync<LocationSuggestions>
                (string.Format(ZomatoSettings.CITIES_ENDPOINT + "?lat={0}&lon={1}", lat, lon));
        }

        public async Task<LocationSuggestions> GetCitiesByNameAsync(string query = null)
        {
            return await _zomatoClient.GetAsync<LocationSuggestions>
                (string.Format(ZomatoSettings.CITIES_ENDPOINT + "?q={0}", query));
        }

        public async Task<CollectionsContainer> GetCollectionsByCityCoordinates(string lat = null, string lon = null)
        {
            return await _zomatoClient.GetAsync<CollectionsContainer>
                (string.Format(ZomatoSettings.COLLECTIONS_ENDPOINT + "?lat={0}&lon={1}", lat, lon));
        }

        public async Task<CollectionsContainer> GetCollectionsByCityId(string id = null)
        {
            return await _zomatoClient.GetAsync<CollectionsContainer>
                (string.Format(ZomatoSettings.COLLECTIONS_ENDPOINT + "?city_id={0}", id));
        }

        public async Task<CuisinesContainer> GetCuisinesByCityCoordinates(string lat = null, string lon = null)
        {
            return await _zomatoClient.GetAsync<CuisinesContainer>
                (string.Format(ZomatoSettings.CUISINES_ENDPOINT + "?lat={0}&lon={1}", lat, lon));
        }

        public async Task<CuisinesContainer> GetCuisinesByCityId(string id = null)
        {
            return await _zomatoClient.GetAsync<CuisinesContainer>
                (string.Format(ZomatoSettings.CUISINES_ENDPOINT + "?city_id={0}", id));
        }

        public async Task<DailyMenusContainer> GetDailyMenusAsync(string id = null)
        {
            return await _zomatoClient.GetAsync<DailyMenusContainer>(
                string.Format(ZomatoSettings.DAILYMENU_URL + "?res_id={0}", id));
        }

        public async Task<EstablishmentsContainer> GetEstablishmentsByCityCoordinates(string lat = null, string lon = null)
        {
            return await _zomatoClient.GetAsync<EstablishmentsContainer>
               (string.Format(ZomatoSettings.ESTABLISHMENTS_ENDPOINT + "?lat={0}&lon={1}", lat, lon));
        }

        public async Task<EstablishmentsContainer> GetEstablishmentsByCityId(string id = null)
        {
            return await _zomatoClient.GetAsync<EstablishmentsContainer>
                (string.Format(ZomatoSettings.ESTABLISHMENTS_ENDPOINT + "?city_id={0}", id));
        }

        public async Task<LocationDetailsContainer> GetLocationDetailsByCoordinatesAsync(string lat = null, string lon = null)
        {
            return await _zomatoClient.GetAsync<LocationDetailsContainer>
                (string.Format(ZomatoSettings.GEOCODE_ENDPOINT + "?lat={0}&lon={1}", lat, lon));
        }

        public async Task<LocationSuggestionContainer> GetLocationSuggestionsAsync(string query = null)
        {
            return await _zomatoClient.GetAsync<Model.Zomato.Locations.LocationSuggestionContainer>
                (string.Format(ZomatoSettings.LOCATION_SUGGESTION_URL + "?query={0}&count=10", query));
        }

        public async Task<Restaurant.RestaurantContainer> GetRestaurantDetailsById(string id = null)
        {
            return await _zomatoClient.GetAsync<Restaurant.RestaurantContainer>
                (string.Format(ZomatoSettings.RESTAURANT_DETAILS_URL + "?res_id={0}", id));
        }

        public async Task<RestaurantsContainer> GetRestaurantsByChoosenLocationAsync(string entityId = null, string entityType = null)
        {
            return await _zomatoClient.GetAsync<RestaurantsContainer>
                (string.Format(ZomatoSettings.SEARCH_URL + "?entity_id={0}&entity_type={1}", entityId, entityType));
        }

        public async Task<UserReviewsContainer> GetReviewsAsync(string id = null, string count = null)
        {
            return await _zomatoClient.GetAsync<UserReviewsContainer>(
                string.Format(ZomatoSettings.REVIEWS_URL + "?res_id={0}&count={1}", id, count));
        }
    }
}
