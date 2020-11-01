using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Geocode
{
    public class Popularity
    {
        public string popularity { get; set; }
        public string nightlife_index { get; set; }
        public List<string> nearby_res { get; set; }
        public List<string> top_cuisines { get; set; }
        public string popularity_res { get; set; }
        public string nightlife_res { get; set; }
        public string subzone { get; set; }
        public int subzone_id { get; set; }
        public string city { get; set; }
    }
}
