using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Reviews
{
    public class UserReview
    {
        [JsonProperty("review")]
        public Review Review { get; set; }
    }
}
