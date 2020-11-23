using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using RestMap.Helpers;
using RestMap.Model.Application;
using RestMap.View;
using RestMap.ViewModel.Commands;

namespace RestMap.ViewModel
{
    public class AddCommentViewModel : INotifyPropertyChanged
    {
        public AddCommentCommand AddCommentCommand { get; set; }

        public AddCommentViewModel()
        {
            AddCommentCommand = new AddCommentCommand(this);
            RestaurantComment = new RestaurantComment();
        }

        private RestaurantComment restaurantComment;

        public RestaurantComment RestaurantComment
        {
            get => restaurantComment;
            set
            {
                restaurantComment = value;
                OnPropertyChanged(nameof(RestaurantComment));
            }
        }

        private string restaurantCommentContent;

        public string RestaurantCommentContent
        {
            get => restaurantCommentContent;
            set
            {
                restaurantCommentContent = value;
                RestaurantComment = new RestaurantComment()
                {
                    CommentContent = this.RestaurantCommentContent
                };
                OnPropertyChanged(nameof(RestaurantCommentContent));
            }
        }

        public  void AddComment(RestaurantComment restaurantComment)
        {
            try
            {
                RestaurantComment.InsertRestaurantComment(restaurantComment);
            }
            catch (Exception e)
            {
                MessageHelper.DisplayMessage("Error", $"Cannot add comment. {e.Message}.", "Ok");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
