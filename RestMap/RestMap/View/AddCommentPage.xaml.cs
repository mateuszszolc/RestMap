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
        private readonly AddCommentViewModel addCommentViewModel;
        public AddCommentPage()
        {
            InitializeComponent();
            addCommentViewModel = new AddCommentViewModel();
            BindingContext = addCommentViewModel;
        }

        private void AddComment_OnClicked(object sender, EventArgs e)
        {
            
        }
    }
}