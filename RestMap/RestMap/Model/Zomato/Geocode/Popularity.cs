using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Geocode
{
    public class Popularity
    {
        [JsonProperty("popularity")]
        public string PopularRate { get; set; }

        [JsonProperty("nightlife_index")]
        public string NightlifeIndex { get; set; }

        [JsonProperty("nearby_res")]
        public List<string> NearbyRes { get; set; }

        [JsonProperty("top_cuisines")]
        public List<string> TopCuisines { get; set; }

        [JsonProperty("popularity_res")]
        public string PopularityRes { get; set; }

        [JsonProperty("nightlife_res")]
        public string NightlifeRes { get; set; }

        [JsonProperty("subzone")]
        public string Subzone { get; set; }

        [JsonProperty("subzone_id")]
        public int SubzoneId { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}
