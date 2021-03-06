using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Restaurant
{
    public class UserRating
    {
        [JsonProperty("aggregate_rating")]
        public string AggregateRating { get; set; }

        [JsonProperty("rating_text")]
        public string RatingText { get; set; }

        [JsonProperty("rating_color")]
        public string RatingColor { get; set; }

        [JsonProperty("rating_obj")]
        public RatingObj RatingObj { get; set; }

        [JsonProperty("votes")]
        public int Votes { get; set; }

        public string rate => AggregateRating + "/5";
    }
}
