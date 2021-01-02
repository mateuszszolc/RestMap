using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Geocode
{
    public class UserRating
    {
        [JsonProperty("aggregate_rating")]
        public object AggregateRating { get; set; }

        [JsonProperty("rating_text")]
        public string RatingText { get; set; }

        [JsonProperty("rating_color")]
        public string RatingColor { get; set; }

        [JsonProperty("rating_obj")]
        public RatingObject RatingObj { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }

        [JsonIgnore]
        public string Rate => AggregateRating.ToString() + "/5";
    }
}
