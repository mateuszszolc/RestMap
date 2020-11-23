using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Daily_Menu
{
    public class DailyMenu
    {
        public string daily_menu_id { get; set; }
        public string start_date { get; set; }
        public string name { get; set; }
        public List<DishContainer> dishes { get; set; }
    }
}
