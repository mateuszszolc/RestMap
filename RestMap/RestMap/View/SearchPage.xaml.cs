using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato;
using RestMap.Model.Zomato.Locations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private async void InputView_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = sender as SearchBar;
            SearchListView.ItemsSource = await LocationSuggestionService.GetLocationSuggestions(searchBar.Text);
        }


        private async void SearchListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            LocationSuggestion locationSuggestion = e.SelectedItem as LocationSuggestion;

            await Navigation.PushAsync(new RestaurantListPage(locationSuggestion));
        }
    }
}