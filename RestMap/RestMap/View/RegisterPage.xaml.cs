using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.Model.Application;
using RestMap.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private readonly RegisterViewModel _registerViewModel;

        public RegisterPage()
        {
            InitializeComponent();
            _registerViewModel = new RegisterViewModel();
            BindingContext = _registerViewModel;
        }

    }
}