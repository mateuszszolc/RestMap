using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Search
{
    public class Restaurant
    {
        public HasMenuStatus has_menu_status { get; set; }
        public int res_id { get; set; }
        public bool is_grocery_store { get; set; }
    }
}
