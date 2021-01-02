using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Reviews
{
    public class UserReviewsContainer
    {
        [JsonProperty("reviews_count")]
        public int ReviewsCount { get; set; }

        [JsonProperty("reviews_start")]
        public int ReviewsStart { get; set; }

        [JsonProperty("reviews_shown")]
        public int ReviewsShown { get; set; }

        [JsonProperty("user_reviews")]
        public List<UserReview> UserReviews { get; set; }
    }
}
