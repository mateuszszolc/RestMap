using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestMap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            IconImage.Source = ImageSource.FromResource("RestMap.Assets.Images.AppIcon.png",
                typeof(MainPage).GetTypeInfo().Assembly);
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new RestaurantListPage());
        }
    }
}