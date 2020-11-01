using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Geocode
{
    public class RestaurantContainer
    {
        public MenuStatus has_menu_status { get; set; }
        public int res_id { get; set; }
        public bool is_grocery_store { get; set; }
    }
}
