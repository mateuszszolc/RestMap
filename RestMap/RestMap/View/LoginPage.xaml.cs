using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Application;
using RestMap.Model.Zomato.Geocode;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            bool login = await ApplicationUser.Login(EmailEntry.Text, PasswordEntry.Text);

            if (login)
                await Navigation.PushAsync(new MapPage());
            else
            {
                await DisplayAlert("Information", "Logging has failed", "Ok");
            }
        }

      
        private async void Button_OnClicked1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}