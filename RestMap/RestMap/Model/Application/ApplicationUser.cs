using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using RestMap.Helpers;
using Xamarin.Forms;

namespace RestMap.Model.Application
{
    public class ApplicationUser : INotifyPropertyChanged
    {
        private string id;

        public string Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string username;

        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value; 
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
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        private bool isActive = true;

        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static async Task<bool> CheckIfUserExistsInDatabase(ApplicationUser appUser)
        {
            
                var applicationUsers = (await App.MobileServiceClient.GetTable<ApplicationUser>()
                    .Where(x => ((x.Email == appUser.Email) || (x.Username == appUser.Username)) && x.IsActive)
                    .ToListAsync());

                if (applicationUsers.Count > 0)
                {
                    return true;
                }

                return false;
        }

        public static async void RemoveAccount(ApplicationUser appUser)
        {
            appUser.IsActive = false;

            await App.MobileServiceClient.GetTable<ApplicationUser>().UpdateAsync(appUser);
        }

        public static async Task<bool> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            var applicationUser = (await App.MobileServiceClient.GetTable<ApplicationUser>()
                    .Where(x => x.Email == email && x.IsActive == true)
                    .ToListAsync())
                    .FirstOrDefault();

            if (applicationUser != null && applicationUser.IsActive)
            {
                if (PasswordHelper.Verify(password, applicationUser.Password))
                {
                    App.ApplicationUser = applicationUser;
                    return true;
                }

                return false;
            }

            return false;
        }

        public static async Task<bool> Register(ApplicationUser appUser)
        {
            var userExists = await CheckIfUserExistsInDatabase(appUser);

            if (userExists)
            {
                return false;
            }
            
            appUser.Password = PasswordHelper.Hash(appUser.Password);
            appUser.ConfirmPassword = PasswordHelper.Hash(appUser.ConfirmPassword);
            await App.MobileServiceClient.GetTable<ApplicationUser>().InsertAsync(appUser);

            return true;
        }

        public static async Task<ApplicationUser> GetApplicationUserById(string id)
        {
            var applicationUserTable = App.MobileServiceClient.GetTable<ApplicationUser>();
            IMobileServiceTableQuery<ApplicationUser> query = applicationUserTable.CreateQuery()
                .Select(x => x)
                .Where(x => x.Id == id);

            var user = (await query.ToListAsync()).FirstOrDefault();

            return user;
        }

        public static async Task<string> GetUsernameByUserId(string id)
        {
            var applicationUSerTable = App.MobileServiceClient.GetTable<ApplicationUser>();

            IMobileServiceTableQuery<string> query = applicationUSerTable.CreateQuery()
                .Where(x => x.Id == id)
                .Select(x => x.Username);

            var username = (await query.ToListAsync()).FirstOrDefault();

            return username;
        }
    }
}
