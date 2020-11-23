using RestMap.View;
using RestMap.ViewModel.Commands.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestMap.ViewModel
{
    public class NotFoundViewModel
    {
        public NavigateToSearchPageCommand NavigateToSearchPageCommand { get; set; }

        public NotFoundViewModel()
        {
            NavigateToSearchPageCommand = new NavigateToSearchPageCommand(this);
        }

        public async void NavigateToSearchPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new SearchPage());
        }
    }
}
