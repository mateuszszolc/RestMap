using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RestMap.ViewModel.Commands.Navigation
{
    public class NavigateToRegisterPageCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly LoginViewModel _loginViewModel;

        public NavigateToRegisterPageCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _loginViewModel.NavigateToRegisterPage();
        }
    }
}
