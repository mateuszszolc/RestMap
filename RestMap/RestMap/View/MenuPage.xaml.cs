using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        private readonly MenuViewModel _menuViewModel;

        public MenuPage()
        {
            InitializeComponent();
            _menuViewModel = new MenuViewModel();
            BindingContext = _menuViewModel;
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();
            _menuViewModel.GetDailyMenus();
        }
    }
}