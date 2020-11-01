using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Geocode
{
    public class Location
    {
        public string entity_type { get; set; }
        public int entity_id { get; set; }
        public string title { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int city_id { get; set; }
        public string city_name { get; set; }
        public int country_id { get; set; }
        public string country_name { get; set; }
    }
}
