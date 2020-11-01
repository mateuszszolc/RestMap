using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Application;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private ApplicationUser _applicationUser;
        public RegisterPage()
        {
            InitializeComponent();
            _applicationUser = new ApplicationUser();
            ContainerStackLayout.BindingContext = _applicationUser;
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            if (PasswordEntry.Text == ConfirmPasswordEntry.Text)
            {
                ApplicationUser.Register(_applicationUser);
            }
            else
            {
                await DisplayAlert("Error", "Passwords don't match", "Ok");
            }
        }
    }
}