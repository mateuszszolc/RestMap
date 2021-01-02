using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Locations
{
    public class LocationSuggestion
    {
        [JsonProperty("entity_type")]
        public string EntityType { get; set; }

        [JsonProperty("entity_id")]
        public int EntityId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("city_id")]
        public int CityId { get; set; }

        [JsonProperty("city_name")]
        public string CityName { get; set; }

        [JsonProperty("country_id")]
        public int CountryId { get; set; }

        [JsonProperty("country_name")]
        public string CountryName { get; set; }
    }
}
