using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Geocode;
using RestMap.Model.Zomato.Locations;

namespace RestMap.Model.Zomato
{
    public static class LocationSuggestionService
    {
        static ZomatoClient zomatoClient = new ZomatoClient();
        static ZomatoService zomatoService = new ZomatoService(zomatoClient);

        public static async Task<List<LocationSuggestion>> GetLocationSuggestions(string query)
        {
            LocationSuggestionContainer locationSuggestionContainer = await zomatoService.GetLocationSuggestionsAsync(query);

            return locationSuggestionContainer.LocationSuggestions;

        }
    }
}
