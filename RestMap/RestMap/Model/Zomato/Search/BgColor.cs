using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Search
{

    public class BgColor
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("tint")]
        public string Tint { get; set; }
    }
}
