using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Restaurant
{
    public class HasMenuStatus
    {
        [JsonProperty("delivery")]
        public int Delivery { get; set; }

        [JsonProperty("takeaway")]
        public int TakeAway { get; set; }
    }
}
