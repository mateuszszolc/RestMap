using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using RestMap.Model.Application;
using Xamarin.Forms;

namespace RestMap.ViewModel
{
    public class UserCommentsPageViewModel
    {
        public ObservableCollection<RestaurantComment> RestaurantComments { get; set; }

        public UserCommentsPageViewModel()
        {
            RestaurantComments = new ObservableCollection<RestaurantComment>();
        }

        public Command RemoveCommentCommand
        {
            get
            {
                return new Command<RestaurantComment>((comment) =>
                {
                    RestaurantComment.RemoveRestaurantComment(comment);
                });
            }
        }

        public async void GetUserRestaurantComments()
        {
            var userComments = await RestaurantComment.GetRestaurantCommentsByUser();

            if (userComments != null)
            {
                RestaurantComments.Clear();

                foreach (var comment in userComments)
                {
                    RestaurantComments.Add(comment);
                }
            }
        }
    }
}
