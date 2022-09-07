// HomePage.xaml.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
using System.Collections.Generic;
using MedicsVerse.ViewModels.Home;
using MedicsVerse.Views.Base;
using Xamarin.Forms;

namespace MedicsVerse.Views.Home
{
    public partial class HomePage : BaseLoggedIn
    {
        private readonly HomeViewModel ViewModel;

        public HomePage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            ViewModel = new HomeViewModel();

            BindingContext = ViewModel;
        }

        void ChatButton_Clicked(System.Object sender, System.EventArgs e)
        {
        }
    }
}

