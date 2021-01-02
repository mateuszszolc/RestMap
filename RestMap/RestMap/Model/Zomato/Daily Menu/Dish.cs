using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Daily_Menu
{
    public class Dish
    {
        [JsonProperty("dish_id")]
        public string DishId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
