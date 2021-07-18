using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Zomato;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Locations;
using RestMap.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        private readonly SearchViewModel _searchViewModel;
        public SearchPage()
        {
            InitializeComponent();
            _searchViewModel = new SearchViewModel();
            BindingContext = _searchViewModel;
        }
    }
}