using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Locations
{
    public class LocationSuggestionContainer
    {
        [JsonProperty("location_suggestions")]
        public List<LocationSuggestion> LocationSuggestions { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("has_more")]
        public int HasMore { get; set; }

        [JsonProperty("has_total")]
        public int HasTotal { get; set; }

        [JsonProperty("user_has_addresses")]
        public bool UserHasAddresses { get; set; }
    }
}
