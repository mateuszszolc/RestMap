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
        private readonly ReviewsViewModel _reviewsViewModel;

        public ReviewsPage()
        {
            InitializeComponent();
            _reviewsViewModel = new ReviewsViewModel();
            BindingContext = _reviewsViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _reviewsViewModel.MergeReviews();
        }

    }
}