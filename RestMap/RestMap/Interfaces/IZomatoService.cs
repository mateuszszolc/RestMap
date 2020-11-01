using RestMap.Model.Zomato.Category;
using RestMap.Model.Zomato.Cities;
using RestMap.Model.Zomato.Collections;
using RestMap.Model.Zomato.Cuisines;
using RestMap.Model.Zomato.Establishments;
using RestMap.Model.Zomato.Geocode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestMap.Interfaces
{
    public interface IZomatoService
    {
        Task<CategoriesContainer> GetCategoriesAsync();
        Task<LocationSuggestions> GetCitiesByNameAsync(string query = null);
        Task<LocationSuggestions> GetCitiesByCoordinatesAsync(string lat = null, string lon = null);
        Task<CollectionsContainer> GetCollectionsByCityId(string id = null);
        Task<CollectionsContainer> GetCollectionsByCityCoordinates(string lat = null, string lon = null);
        Task<CuisinesContainer> GetCuisinesByCityId(string id = null);
        Task<CuisinesContainer> GetCuisinesByCityCoordinates(string lat = null, string lon = null);
        Task<EstablishmentsContainer> GetEstablishmentsByCityId(string id = null);
        Task<EstablishmentsContainer> GetEstablishmentsByCityCoordinates(string lat = null, string lon = null);
        Task<LocationDetailsContainer> GetLocationDetailsByCoordinatesAsync(string lat = null, string lon = null);
        Task<Model.Zomato.Restaurant.RestaurantContainer> GetRestaurantDetailsById(string id = null);
        Task<Model.Zomato.Locations.LocationSuggestionContainer> GetLocationSuggestionsAsync(string query = null);
    }
}
