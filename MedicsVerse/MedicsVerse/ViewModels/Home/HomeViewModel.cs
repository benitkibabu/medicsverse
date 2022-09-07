// HomeViewModel.cs
// Author:  benitkibabu 
// Date: 07/09/2022
using System;
using System.Collections.Generic;
using MedicsVerse.Models;

namespace MedicsVerse.ViewModels.Home
{
    public class HomeViewModel : BaseViewModel
    {
        private List<Post> post;
        private User loggedInUser;

        public HomeViewModel()
        {
            Posts = new List<Post>()
            {
                Post.Post1(),
                Post.Post2()
            };

            LoggedInUser = User.GetUser1();
        }

        public List<Post> Posts
        {
            set { SetProperty(ref post, value); }
            get { return post; }
        }

        public User LoggedInUser
        {
            set { SetProperty(ref loggedInUser, value); }
            get { return loggedInUser; }
        }


    }
}

