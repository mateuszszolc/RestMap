using RestMap.Model.Zomato;
using RestMap.Model.Zomato.API_Service;
using RestMap.Model.Zomato.Geocode;
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
    public partial class RestaurantListPage : ContentPage
    {
        
        static Filter filter = new Filter();

        LocationDetailsContainer locationDetailsContainer = new LocationDetailsContainer();
        static ZomatoClient zomatoClient = new ZomatoClient();
        ZomatoService zomatoService = new ZomatoService(zomatoClient);
        private List<NearbyRestaurant> nearbyRestaurants = new List<NearbyRestaurant>();

       
        

        public RestaurantListPage()
        {
            InitializeComponent();
            //GetRestaurants();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //GetRestaurants();
            if (true)
                BindingContext = await NearbyRestaurantsService.GetRestaurants();
            //BindingContext = App.NearbyRestaurants;
            else
                await Navigation.PushAsync(new NotFoundPage());
        }


        public List<Filter> FilterList => filter.GetFilters();

        public async void GetRestaurants()
         {
             locationDetailsContainer = await zomatoService.GetLocationDetailsByCoordinatesAsync("52.237049", "21.017532");            

             nearbyRestaurants = locationDetailsContainer.nearby_restaurants;            
         }

        public async void SetRestaurants()
        {
            //nearbyRestaurants = await GetRestaurants();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var view = sender as Xamarin.Forms.View;
            var parent = view.Parent as StackLayout;

            foreach (var child in parent.Children)
            {
                VisualStateManager.GoToState(child, "Normal");
                ChangeTextColor(child, "#707070");
            }

            VisualStateManager.GoToState(view, "Selected");
            ChangeTextColor(view, "#FFFFFF");
        }

        private void ChangeTextColor(Xamarin.Forms.View child, string hexColor)
        {
            var txtCtrl = child.FindByName<Label>("FilterSettingsLabel");

            if (txtCtrl != null)
                txtCtrl.TextColor = Color.FromHex(hexColor);
        }

        

         private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
          {
            string property = ((sender as Xamarin.Forms.View).BindingContext as NearbyRestaurant).restaurant.id;
            await Navigation.PushAsync(new RestaurantDetailsPage(property));
          }

        
    }
   
}