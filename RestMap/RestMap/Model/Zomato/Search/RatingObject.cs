using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Search
{
    public class RatingObj
    {
        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("bg_color")]
        public BgColor BgColor { get; set; }
    }
}
