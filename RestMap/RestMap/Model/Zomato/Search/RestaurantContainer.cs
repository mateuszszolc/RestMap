using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Search
{
    public class RestaurantContainer
    {
        [JsonProperty("restaurant")]
        public SpecificRestaurant Restaurant { get; set; }
    }
}
