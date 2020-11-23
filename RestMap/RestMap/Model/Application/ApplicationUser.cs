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

        public static async Task<bool> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            var applicationUser = (await App.MobileServiceClient.GetTable<ApplicationUser>()
                    .Where(x => x.Email == email)
                    .ToListAsync())
                    .FirstOrDefault();

            if (applicationUser != null && applicationUser.IsActive)
            {
                App.ApplicationUser = applicationUser;
                if (PasswordHelper.Verify(password, applicationUser.Password))
                    return true;
                return false;
            }

            return false;
        }

        public static async void Register(ApplicationUser appUser)
        {
            appUser.Password = PasswordHelper.Hash(appUser.Password);
            await App.MobileServiceClient.GetTable<ApplicationUser>().InsertAsync(appUser);
        }

        public static async Task<ApplicationUser> GetApplicationUserById(string id)
        {
            //ApplicationUser appUser =  (await App.MobileServiceClient.GetTable<ApplicationUser>()
            //        .Where(x => x.Id == id)
            //        .ToListAsync())
            //        .FirstOrDefault();
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
