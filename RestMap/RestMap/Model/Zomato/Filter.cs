using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato
{
    public class Filter
    {
        public string FilterName { get; set; }

        public List<Filter> GetFilters()
        {
            return new List<Filter>()
            {
                new Filter {FilterName = "Cost" },
                new Filter {FilterName = "Rating" },
                new Filter {FilterName = "Distance" }
            };
        }
    }
}
