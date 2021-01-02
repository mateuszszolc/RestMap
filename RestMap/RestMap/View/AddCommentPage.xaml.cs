using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestMap.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCommentPage : ContentPage
    {
        private readonly AddCommentViewModel _addCommentViewModel;

        public AddCommentPage()
        {
            InitializeComponent();
            _addCommentViewModel = new AddCommentViewModel();
            BindingContext = _addCommentViewModel;
        }
    }
}