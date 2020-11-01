using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Collections
{
    public class Collection
    {
        public int collection_id { get; set; }
        public int res_count { get; set; }
        public string image_url { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string share_url { get; set; }
    }
}
