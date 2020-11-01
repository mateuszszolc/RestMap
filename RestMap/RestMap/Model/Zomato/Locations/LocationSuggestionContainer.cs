using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Locations
{
    public class LocationSuggestionContainer
    {
        public List<LocationSuggestion> location_suggestions { get; set; }
        public string status { get; set; }
        public int has_more { get; set; }
        public int has_total { get; set; }
        public bool user_has_addresses { get; set; }
    }
}
