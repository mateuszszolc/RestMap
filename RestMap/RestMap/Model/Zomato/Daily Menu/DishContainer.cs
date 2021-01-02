using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Daily_Menu
{
    public class DishContainer
    {
        [JsonProperty("dish")]
        public Dish Dish { get; set; }
    }
}
