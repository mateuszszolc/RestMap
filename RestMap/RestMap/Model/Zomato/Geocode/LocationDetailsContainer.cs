using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Geocode
{
    public class LocationDetailsContainer
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("popularity")]
        public Popularity Popularity { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("nearby_restaurants")]
        public List<NearbyRestaurant> NearbyRestaurants { get; set; }
    }
}
