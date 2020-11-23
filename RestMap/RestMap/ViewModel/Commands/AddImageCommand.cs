using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using RestMap.Model.Application;

namespace RestMap.ViewModel.Commands
{
    public class AddImageCommand : ICommand
    {
        private ReviewsViewModel reviewsViewModel;
        public event EventHandler CanExecuteChanged;

        public AddImageCommand(ReviewsViewModel reviewsViewModel)
        {
            this.reviewsViewModel = reviewsViewModel;
        }

        public bool CanExecute(object parameter)
        {
            var restaurantImage = parameter as RestaurantImage;

            if (restaurantImage != null)
            {
                if (string.IsNullOrEmpty(restaurantImage.ImageUrl))
                {
                    return false;
                }
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            
        }

    }
}
