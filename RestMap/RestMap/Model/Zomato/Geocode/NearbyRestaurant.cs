using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Geocode
{
    public class NearbyRestaurant
    {
        [JsonProperty("restaurant")]
        public Restaurant Restaurant { get; set; }
    }
}
