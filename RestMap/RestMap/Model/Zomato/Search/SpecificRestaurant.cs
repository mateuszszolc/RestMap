using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace RestMap.Model.Zomato.Search
{
    public class SpecificRestaurant
    {
        [JsonProperty("R")]
        public Restaurant R { get; set; }

        [JsonProperty("apikey")]
        public string ApiKey { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("switch_to_order_menu")]
        public int SwitchToOrderMenu { get; set; }

        [JsonProperty("cuisines")]
        public string Cuisines { get; set; }

        [JsonProperty("timings")]
        public string Timings { get; set; }

        [JsonProperty("average_cost_for_two")]
        public int AverageCostForTwo { get; set; }

        [JsonProperty("price_range")]
        public int PriceRange { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("highlights")]
        public List<string> Highlights { get; set; }

        [JsonProperty("offers")]
        public List<object> Offers { get; set; }

        [JsonProperty("opentable_support")]
        public int OpentableSupport { get; set; }

        [JsonProperty("is_zomato_book_res")]
        public int IsZomatoBookRes { get; set; }

        [JsonProperty("mezzo_provider")]
        public string MezzoProvider { get; set; }

        [JsonProperty("is_book_form_web_view")]
        public int IsBookFormWebUrl { get; set; }

        [JsonProperty("book_form_web_view_url")]
        public string BookFormWebViewUrl { get; set; }

        [JsonProperty("book_again_url")]
        public string BookAgainUrl { get; set; }

        [JsonProperty("thumb")]
        public string Thumb { get; set; }

        [JsonProperty("user_rating")]
        public UserRating UserRating { get; set; }

        [JsonProperty("all_reviews_count")]
        public int AllReviewsCount { get; set; }

        [JsonProperty("photos_url")]
        public string PhotosUrl { get; set; }

        [JsonProperty("photo_count")]
        public int PhotoCount { get; set; }

        [JsonProperty("menu_url")]
        public string MenuUrl { get; set; }

        [JsonProperty("featured_image")]
        public string FeaturedImage { get; set; }

        [JsonProperty("has_online_delivery")]
        public int HasOnlineDelivery { get; set; }

        [JsonProperty("is_delivering_now")]
        public int IsDeliveringNow { get; set; }

        [JsonProperty("store_type")]
        public string StoreType { get; set; }

        [JsonProperty("include_bogo_offers")]
        public bool IncludeBogoOffers { get; set; }

        [JsonProperty("deeplink")]
        public string Deeplink { get; set; }

        [JsonProperty("is_table_reservation_supported")]
        public int IsTableReservationSupported { get; set; }

        [JsonProperty("has_table_booking")]
        public int HasTableBooking { get; set; }

        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }

        [JsonProperty("phone_numbers")]
        public string PhoneNumbers { get; set; }

        [JsonProperty("all_reviews")]
        public AllReviews AllReviews { get; set; }

        [JsonProperty("establishment")]
        public List<string> Establishment { get; set; }

        [JsonProperty("establishment_types")]
        public List<object> EstablishmentTypes { get; set; }

        [JsonIgnore]
        public List<string> CuisinesList => Cuisines.Split(',').ToList().Select(x => x.Trim()).ToList();

        [JsonIgnore]
        public string AverageCost => AverageCostForTwo.ToString() + " " + Currency;
    }
}
