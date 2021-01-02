using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Search
{
    public class Location
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("locality")]
        public string Locality { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("city_id")]
        public int CityId { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [JsonProperty("country_id")]
        public int CountryId { get; set; }
        
        [JsonProperty("locality_verbose")]
        public string LocalityVerbose { get; set; }
    }
}
