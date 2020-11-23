using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private List<string> SettingsList;
        public SettingsPage()
        {
            InitializeComponent();
            SettingsList = new List<string>() {"Add a place", "My Images", "My Comments", "My Favourites Restaurants", "Delete My Account" };
            SettingsListView.ItemsSource = SettingsList;
        }

        private async void SettingsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await DisplayAlert("Title", e.SelectedItem.ToString(), "Ok");
        }
    }
}