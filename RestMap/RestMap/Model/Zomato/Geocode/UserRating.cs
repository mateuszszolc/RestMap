using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Geocode
{
    public class UserRating
    {
        public object aggregate_rating { get; set; }
        public string rating_text { get; set; }
        public string rating_color { get; set; }
        public RatingObject rating_obj { get; set; }
        public int votes { get; set; }

        public string rate => aggregate_rating.ToString() + "/5";
    }
}
