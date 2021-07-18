using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Application;
using RestMap.Model.Zomato.Geocode;
using RestMap.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _loginViewModel;

        public LoginPage()
        {
            InitializeComponent();
            _loginViewModel = new LoginViewModel();
            BindingContext = _loginViewModel;
        }

        protected override bool OnBackButtonPressed() => false;
    }
}