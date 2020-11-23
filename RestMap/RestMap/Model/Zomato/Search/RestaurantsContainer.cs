using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Search
{
    public class RestaurantsContainer
    {
        public int results_found { get; set; }
        public int results_start { get; set; }
        public int results_shown { get; set; }
        public List<RestaurantContainer> restaurants { get; set; }
    }
}
