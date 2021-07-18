using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using RestMap.Model.Other;
using RestMap.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private readonly SettingsViewModel _settingsViewModel;

        public SettingsPage()
        {
            InitializeComponent();
            _settingsViewModel = new SettingsViewModel();
            BindingContext = _settingsViewModel;
        }


        private async void SettingsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await DisplayAlert("Title", e.SelectedItem.ToString(), "Ok");
        }
    }
}