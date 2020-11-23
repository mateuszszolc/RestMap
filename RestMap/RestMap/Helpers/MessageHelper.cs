using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.Helpers
{
    public static class MessageHelper
    {
        public static async void DisplayMessage(string caption, string information, string buttonValue)
        {
            await App.Current.MainPage.DisplayAlert(caption, information, buttonValue);
        }
    }
}
