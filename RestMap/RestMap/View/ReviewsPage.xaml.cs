using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewsPage : ContentPage
    {
        private ReviewsViewModel reviewsViewModel;

        public ReviewsPage()
        {
            InitializeComponent();
            reviewsViewModel = new ReviewsViewModel();
            BindingContext = reviewsViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //reviewsViewModel.GetReviews();
            //await reviewsViewModel.GetReviews();
            await reviewsViewModel.MergeReviews();
        }

        private async void AddComment_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCommentPage());
        }
    }
}