using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RestMap.Helpers;
using RestMap.Model.Other;
using RestMap.View;

namespace RestMap.ViewModel
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public List<SettingsModel> SettingsModels { get; set; }

        private SettingsModel settingsModel;

        public SettingsModel SettingsModel
        {
            get => settingsModel;
            set
            {
                settingsModel = value;
                OnPropertyChanged(nameof(SettingsModel));
                var choosenSettingsModel = SettingsModel;

                if (choosenSettingsModel.Id == 1)
                {
                    App.Current.MainPage.Navigation.PushAsync(new UserRestaurantsPage());
                }
                else if (choosenSettingsModel.Id == 2)
                { 
                    App.Current.MainPage.Navigation.PushAsync(new UserCommentsPage());
                }
                else if (choosenSettingsModel.Id == 3)
                {
                    App.Current.MainPage.Navigation.PushAsync(new UserImagesPage());
                }
                else if (choosenSettingsModel.Id == 4)
                {
                    MessageHelper.RemoveAccount();
                }
            }
        }

        public SettingsViewModel()
        {
            SettingsModels = SettingsModel.GetSettings();
            settingsModel = new SettingsModel();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
