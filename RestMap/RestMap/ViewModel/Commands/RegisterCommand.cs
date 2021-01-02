using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RestMap.Model.Application;

namespace RestMap.ViewModel.Commands
{
    public class RegisterCommand : ICommand
    {
        private readonly RegisterViewModel _registerViewModel;

        public RegisterCommand(RegisterViewModel registerViewModel)
        {
            _registerViewModel = registerViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            ApplicationUser applicationUser = parameter as ApplicationUser;

            if (applicationUser != null)
            {
                if (applicationUser.Password == applicationUser.ConfirmPassword)
                {
                    if (string.IsNullOrEmpty(applicationUser.Email) || string.IsNullOrEmpty(applicationUser.Password) ||
                        string.IsNullOrEmpty(applicationUser.Username))
                    {
                        return false;
                    }

                    return true;
                }

                return false;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            ApplicationUser user = (ApplicationUser) parameter;
            _registerViewModel.Register(user);
        }
    }
}
