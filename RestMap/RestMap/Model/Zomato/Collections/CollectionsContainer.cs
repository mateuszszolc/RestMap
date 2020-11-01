using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Collections
{
    public class CollectionsContainer
    {
        public List<CollectionContainer> collections { get; set; }
        public int has_more { get; set; }
        public string share_url { get; set; }
        public string display_text { get; set; }
        public int has_total { get; set; }
        public bool user_has_addresses { get; set; }
    }
}
