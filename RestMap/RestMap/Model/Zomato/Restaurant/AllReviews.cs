using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Restaurant
{
    public class AllReviews
    {
        [JsonProperty("reviews")]
        public List<Review> Reviews { get; set; }
    }
}
