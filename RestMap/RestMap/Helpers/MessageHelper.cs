using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Application;
using RestMap.View;

namespace RestMap.Helpers
{
    public static class MessageHelper
    {
        public static async void DisplayMessage(string caption, string information, string buttonValue)
        {
            await App.Current.MainPage.DisplayAlert(caption, information, buttonValue);
        }

        public static async void RemoveAccount()
        {
            var result =
                await App.Current.MainPage.DisplayAlert("Info", "Do you want to remove your account?", "Yes", "No");

            if (result)
            {
                ApplicationUser.RemoveAccount(App.ApplicationUser);
                await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
        }
    }
}
