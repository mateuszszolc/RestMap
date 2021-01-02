using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Daily_Menu
{
    public class DailyMenu
    {
        [JsonProperty("daily_menu_id")]
        public string DailyMenuId { get; set; }

        [JsonProperty("start_date")]
        public string StartDate { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("dishes")]
        public List<DishContainer> Dishes { get; set; }
    }
}
