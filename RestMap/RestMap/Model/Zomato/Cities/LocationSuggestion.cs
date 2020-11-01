using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Cities
{
    public class LocationSuggestion
    {
        public int id { get; set; }
        public string name { get; set; }
        public int country_id { get; set; }
        public string country_name { get; set; }
        public string country_flag_url { get; set; }
        public int should_experiment_with { get; set; }
        public int has_go_out_tab { get; set; }
        public int discovery_enabled { get; set; }
        public int has_new_ad_format { get; set; }
        public int is_state { get; set; }
        public int state_id { get; set; }
        public string state_name { get; set; }
        public string state_code { get; set; }
    }
}
