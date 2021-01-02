using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Search
{
    public class AllReviews
    {
        [JsonProperty("reviews")]
        public List<object> Reviews { get; set; }
    }
}
