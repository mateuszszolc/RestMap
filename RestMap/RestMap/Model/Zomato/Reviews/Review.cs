﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Reviews
{
    public class Review
    {
        public string rating { get; set; }
        public string review_text { get; set; }
        public int id { get; set; }
        public string rating_color { get; set; }
        public string review_time_friendly { get; set; }
        public string rating_text { get; set; }
        public int timestamp { get; set; }
        public int likes { get; set; }
        public User user { get; set; }
        public int comments_count { get; set; }
    }
}