using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Search
{
    public class RestaurantsContainer
    {
        [JsonProperty("results_found")]
        public int ResultsFound { get; set; }

        [JsonProperty("results_start")]
        public int ResultsStart { get; set; }

        [JsonProperty("results_shown")]
        public int ResultsShown { get; set; }

        [JsonProperty("restaurants")]
        public List<RestaurantContainer> Restaurants { get; set; }
    }
}
