using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Reviews
{
    public class User
    {
        public string name { get; set; }
        public string foodie_level { get; set; }
        public int foodie_level_num { get; set; }
        public string foodie_color { get; set; }
        public string profile_url { get; set; }
        public string profile_image { get; set; }
        public string profile_deeplink { get; set; }
        public string zomato_handle { get; set; }
    }
}
