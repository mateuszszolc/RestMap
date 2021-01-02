using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Geocode
{
    public class Location
    {
        [JsonProperty("entity_type")]
        public string EntityType { get; set; }

        [JsonProperty("entity_id")]
        public int EntityId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

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
