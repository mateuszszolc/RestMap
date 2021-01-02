using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using RestMap.Helpers;
using RestMap.Model.Application;
using RestMap.Validator;
using RestMap.View;
using RestMap.ViewModel.Commands;

namespace RestMap.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
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
                    Username = this.Username,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
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
                    Username = this.Username,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged(nameof(Password));
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get => confirmPassword;
            set
            {
                confirmPassword = value;
                ApplicationUser = new ApplicationUser()
                {
                    Email = this.Email,
                    Username = this.Username,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        private string username;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                ApplicationUser = new ApplicationUser()
                {
                    Email = this.Email,
                    Username = this.Username,
                    Password = this.Password,
                    ConfirmPassword = this.ConfirmPassword
                };
                OnPropertyChanged(nameof(Username));
            }
        }

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

        public RegisterCommand RegisterCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterViewModel()
        {
            RegisterCommand = new RegisterCommand(this);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void Register(ApplicationUser user)
        {
            if (!EmailValidator.IsEmailValid(user.Email))
            {
                MessageHelper.DisplayMessage("Error", "The Email address is invalid.", "Ok");
            }
            else
            {
                var result = await ApplicationUser.Register(user);

                if (result)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    MessageHelper.DisplayMessage("Error", "User with the same username or email already exists in database.", "Ok");
                }
            }
        }
    }
}
