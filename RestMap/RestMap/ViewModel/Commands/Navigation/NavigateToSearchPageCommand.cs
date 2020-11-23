using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace RestMap.ViewModel.Commands.Navigation
{
    public class NavigateToSearchPageCommand : ICommand
    {
        private readonly NotFoundViewModel _notFoundViewModel;

        public NavigateToSearchPageCommand(NotFoundViewModel notFoundViewModel)
        {
            _notFoundViewModel = notFoundViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _notFoundViewModel.NavigateToSearchPage();
        }
    }
}
