using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Geocode
{
    public class BackgroundColor
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("tint")]
        public string Tint { get; set; }
    }
}
