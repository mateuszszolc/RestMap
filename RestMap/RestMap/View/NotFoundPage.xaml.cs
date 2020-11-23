using RestMap.ViewModel;
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
    public partial class NotFoundPage : ContentPage
    {
        private readonly NotFoundViewModel _notFoundViewModel;
        public NotFoundPage()
        {
            InitializeComponent();
            _notFoundViewModel = new NotFoundViewModel();
            BindingContext = _notFoundViewModel;
        }
    }
}