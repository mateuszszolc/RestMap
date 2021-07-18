using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Application;
using RestMap.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserImagesPage : ContentPage
    {
        private readonly UserImagesViewModel _userImagesViewModel;

        public UserImagesPage()
        {
            InitializeComponent();
            _userImagesViewModel = new UserImagesViewModel();
            BindingContext = _userImagesViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _userImagesViewModel.GetUserRestaurantImages();
        }

        private void RemoveBtnClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            var image = button?.BindingContext as RestaurantImage;

            var viewModel = BindingContext as UserImagesViewModel;

            viewModel.RemoveImageCommand.Execute(image);

            OnAppearing();
        }
    }
}