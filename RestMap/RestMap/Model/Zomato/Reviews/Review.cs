using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Reviews
{
    public class Review
    {
        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("review_text")]
        public string ReviewText { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rating_color")]
        public string RatingColor { get; set; }

        [JsonProperty("review_time_friendly")]
        public string ReviewTimeFriendly { get; set; }

        [JsonProperty("rating_text")]
        public string RatingText { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("comments_count")]
        public int CommentsCount { get; set; }
    }
}
