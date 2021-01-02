using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Restaurant
{
    public class Review
    {
        [JsonProperty("review")]
        public List<object> Reviews { get; set; }
    }
}
