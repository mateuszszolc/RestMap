using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using RestMap.Helpers;
using RestMap.Model.Application;
using RestMap.View;
using RestMap.ViewModel.Commands;
using RestMap.ViewModel.Commands.Navigation;

namespace RestMap.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginCommand LoginCommand { get; set; }
        public NavigateToRegisterPageCommand NavigateToRegisterPageCommand{ get; set; }

        private ApplicationUser applicationUser;

        public ApplicationUser ApplicationUser
        {
            get => applicationUser;
            set
            {
                applicationUser = value;
                OnPropertyChanged(nameof(ApplicationUser));
            }
        }

        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                ApplicationUser = new ApplicationUser()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged(nameof(Email));
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                ApplicationUser = new ApplicationUser()
                {
                    Email = this.Email,
                    Password = this.Password
                };
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel()
        {
            ApplicationUser = new ApplicationUser();
            LoginCommand = new LoginCommand(this);
            NavigateToRegisterPageCommand = new NavigateToRegisterPageCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void Login()
        {
            bool login = await ApplicationUser.Login(ApplicationUser.Email, ApplicationUser.Password);

            if (login)
                await App.Current.MainPage.Navigation.PushAsync(new MapPage());
            else
            {
                MessageHelper.DisplayMessage("Information", "Logging has failed", "Ok");
            }
        }

        public async void NavigateToRegisterPage()
        {
            await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }
    }
}
