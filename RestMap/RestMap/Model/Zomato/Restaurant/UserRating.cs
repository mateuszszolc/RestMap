using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Restaurant
{
    public class UserRating
    {
        public string aggregate_rating { get; set; }
        public string rating_text { get; set; }
        public string rating_color { get; set; }
        public RatingObj rating_obj { get; set; }
        public int votes { get; set; }

        public string rate => aggregate_rating + "/5";
    }
}
