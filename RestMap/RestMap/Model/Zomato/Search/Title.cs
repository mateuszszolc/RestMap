using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Search
{
    public class Title
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
