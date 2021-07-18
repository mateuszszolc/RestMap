using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Application;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Restaurant;
using RestMap.Model.Zomato.Reviews;
using RestMap.View;
using Xamarin.Forms;

namespace RestMap.ViewModel
{
    public class ReviewsViewModel
    {
        public Command NavigateToAddCommentPageCommand { get; set; }
        public RestaurantContainer RestaurantContainer { get; set; }
        public ObservableCollection<UserReview> UserReviews { get; set; }
        private ObservableCollection<RestaurantComment> _restaurantComments;
        private ObservableCollection<ApplicationUser> _appUsers;
        private List<string> userNames;
        private readonly ZomatoServiceWorker _serviceWorker;

        public ReviewsViewModel()
        {
            RestaurantContainer = new RestaurantContainer();
            NavigateToAddCommentPageCommand = new Command(async () => await NavigateToAddCommentPage());
            UserReviews = new ObservableCollection<UserReview>();
            _restaurantComments = new ObservableCollection<RestaurantComment>();
            _appUsers = new ObservableCollection<ApplicationUser>();
            userNames = new List<string>();
            _serviceWorker = new ZomatoServiceWorker();

            if (App.RestaurantsContainer != null)
            {
                RestaurantContainer = App.RestaurantsContainer;
            }
        }

        public async Task NavigateToAddCommentPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddCommentPage());
        }

        public async Task GetReviewsFromDb()
        {
            var reviewsFromDbTask = RestaurantComment.GetRestaurantComments();
            await reviewsFromDbTask;
            var reviewsFromDb = reviewsFromDbTask.GetAwaiter().GetResult();

            if (reviewsFromDb != null)
            {
                if (reviewsFromDb.Count > 0)
                {
                    _restaurantComments.Clear();

                    foreach (var review in reviewsFromDb)
                    {
                        _restaurantComments.Add(review);
                    }
                }
            }
        }

        public async Task MergeReviews()
        {

            await GetReviews();
            await GetReviewsFromDb();
            await GetApplicationUsers();

            if (_restaurantComments.Count > 0)
            {
                UserReview userReview = new UserReview();
                var review = new Model.Zomato.Reviews.Review();
                var user = new User();
                review.User = user;
                userReview.Review = review;


                for(int i = 0; i < _restaurantComments.Count; i++)
                {
                    userReview.Review.ReviewText = _restaurantComments[i].CommentContent;
                    userReview.Review.User.Name = _appUsers[i].Username;

                    UserReviews.Add(userReview);
                }
            }
        }

        private async Task GetApplicationUsers()
        {
            if (_restaurantComments.Count > 0)
            {

                foreach (var comment in _restaurantComments)
                {
                    var task = ApplicationUser.GetApplicationUserById(comment.ApplicationUserId);
                   await task;
                   var user = task.GetAwaiter().GetResult();
                    _appUsers.Add(user);
                }

            }
        }

        public async Task GetReviews()
        {
            if (App.RestaurantsContainer != null)
            {

                var task = _serviceWorker.GetReviewsAsync(App.RestaurantsContainer.Id, "10");
                await task;
                var userReviews = task.GetAwaiter().GetResult();

                if (userReviews != null)
                {
                    UserReviews.Clear();

                    foreach (var review in userReviews)
                    {
                        UserReviews.Add(review);
                    }
                }
            }
        }
    }
}
