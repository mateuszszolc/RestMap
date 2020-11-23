using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestMap.Model.Zomato.Restaurant
{
    public class RestaurantContainer
    {
        public Restaurant R { get; set; }
        public string apikey { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public Location location { get; set; }
        public int switch_to_order_menu { get; set; }
        public string cuisines { get; set; }
        public string timings { get; set; }
        public int average_cost_for_two { get; set; }
        public int price_range { get; set; }
        public string currency { get; set; }
        public List<string> highlights { get; set; }
        public List<object> offers { get; set; }
        public int opentable_support { get; set; }
        public int is_zomato_book_res { get; set; }
        public string mezzo_provider { get; set; }
        public int is_book_form_web_view { get; set; }
        public string book_form_web_view_url { get; set; }
        public string book_again_url { get; set; }
        public string thumb { get; set; }
        public UserRating user_rating { get; set; }
        public int all_reviews_count { get; set; }
        public string photos_url { get; set; }
        public int photo_count { get; set; }
        public string menu_url { get; set; }
        public string featured_image { get; set; }
        public int has_online_delivery { get; set; }
        public int is_delivering_now { get; set; }
        public string store_type { get; set; }
        public bool include_bogo_offers { get; set; }
        public string deeplink { get; set; }
        public int is_table_reservation_supported { get; set; }
        public int has_table_booking { get; set; }
        public string events_url { get; set; }
        public string phone_numbers { get; set; }
        public AllReviews all_reviews { get; set; }
        public List<string> establishment { get; set; }

        public List<string> cuisinesList => cuisines.Split(',').ToList().Select(x => x.Trim()).ToList();

        
        public string average_cost => average_cost_for_two.ToString() + " " + currency;

       
    }
}
