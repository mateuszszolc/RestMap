using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Reviews
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("foodie_level")]
        public string FoodieLevel { get; set; }

        [JsonProperty("foodie_level_num")]
        public int FoodieLevelNum { get; set; }

        [JsonProperty("foodie_color")]
        public string FoodieColor { get; set; }

        [JsonProperty("profile_url")]
        public string ProfileUrl { get; set; }

        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }

        [JsonProperty("profile_deeplink")]
        public string ProfileDeeplink { get; set; }

        [JsonProperty("zomato_handle")]
        public string ZomatoHandle { get; set; }
    }
}
