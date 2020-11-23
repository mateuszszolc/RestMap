using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Model.Zomato.Reviews
{
    public class UserReviewsContainer
    {
        public int reviews_count { get; set; }
        public int reviews_start { get; set; }
        public int reviews_shown { get; set; }
        public List<UserReview> user_reviews { get; set; }
    }
}
