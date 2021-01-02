using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Restaurant
{
   public class Restaurant
    {
        [JsonProperty("has_menu_status")]
        public HasMenuStatus HasMenuStatus { get; set; }

        [JsonProperty("res_id")]
        public int ResId { get; set; }

        [JsonProperty("is_grocery_store")]
        public bool IsGroceryStore { get; set; }
    }
}
