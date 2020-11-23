using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Settings
{
    public static class ZomatoSettings
    {
        public static readonly string API_KEY = "e4de21a416ae2c8d522b7b47f71c234e";

        public static readonly string BASE_URL = "https://developers.zomato.com/api/v2.1/";

        public static readonly string HEADER = "X-Zomato-API-Key";

        public static readonly string CATEGORY_ENDPOINT = "categories";

        public static readonly string CITIES_ENDPOINT = "cities";

        public static readonly string COLLECTIONS_ENDPOINT = "collections";

        public static readonly string CUISINES_ENDPOINT = "cuisines";

        public static readonly string ESTABLISHMENTS_ENDPOINT = "establishments";

        public static readonly string GEOCODE_ENDPOINT = "geocode";

        public static readonly string RESTAURANT_DETAILS_URL = "restaurant";

        public static readonly string LOCATION_SUGGESTION_URL = "locations";

        public static readonly string SEARCH_URL = "search";

        public static readonly string DAILYMENU_URL = "dailymenu";

        public static readonly string REVIEWS_URL = "reviews";
    }
}
