using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Daily_Menu
{
    public class DailyMenuContainer
    {
        [JsonProperty("daily_menu")]
        public DailyMenu DailyMenu { get; set; }
    }
}
