using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RestMap.Model.Application;

namespace RestMap.ViewModel.Commands
{
    public class AddCommentCommand : ICommand
    {
        private AddCommentViewModel addCommandViewModel;

        public AddCommentCommand(AddCommentViewModel addCommandViewModel)
        {
            this.addCommandViewModel = addCommandViewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter is RestaurantComment comment && !string.IsNullOrEmpty(comment.CommentContent))
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var comment = (RestaurantComment) parameter;
            addCommandViewModel.AddComment(comment);
        }

        public event EventHandler CanExecuteChanged;
    }
}
