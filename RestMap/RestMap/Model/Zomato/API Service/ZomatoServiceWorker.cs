using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato.Reviews;

namespace RestMap.Model.Zomato.API_Service
{
    public static class ZomatoServiceWorker
    {
        private static readonly ZomatoClient _zomatoClient = new ZomatoClient();
        private static  readonly ZomatoService _zomatoService = new ZomatoService(_zomatoClient);

        public static async Task<List<UserReview>> GetReviewsAsync(string id, string count)
        {
            var userReviewsContainer = await _zomatoService.GetReviewsAsync(id, count);

            return userReviewsContainer?.UserReviews;
        }
    }
}
