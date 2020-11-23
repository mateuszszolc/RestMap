using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Daily_Menu
{
    public class DailyMenusContainer
    {
        public List<DailyMenuContainer> daily_menus { get; set; }
        public string status { get; set; }
    }
}
