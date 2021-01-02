using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Daily_Menu
{
    public class DailyMenusContainer
    {
        [JsonProperty("daily_menus")]
        public List<DailyMenuContainer> DailyMenus { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
