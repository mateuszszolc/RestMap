using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Geocode
{
    public class LocationDetailsContainer
    {
        public Location location { get; set; }
        public Popularity popularity { get; set; }
        public string link { get; set; }
        public List<NearbyRestaurant> nearby_restaurants { get; set; }
    }
}
