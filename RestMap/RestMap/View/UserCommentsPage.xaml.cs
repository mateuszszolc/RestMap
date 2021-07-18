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
    public partial class UserCommentsPage : ContentPage
    {
        private readonly UserCommentsPageViewModel _userCommentsPageViewModel;

        public UserCommentsPage()
        {
            InitializeComponent();
            _userCommentsPageViewModel = new UserCommentsPageViewModel();
            BindingContext = _userCommentsPageViewModel;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _userCommentsPageViewModel.GetUserRestaurantComments();
        }

        private void RemoveBtnClicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            var comment = button?.BindingContext as RestaurantComment;

            var viewModel = BindingContext as UserCommentsPageViewModel;

            viewModel.RemoveCommentCommand.Execute(comment);

            OnAppearing();
        }
    }
}