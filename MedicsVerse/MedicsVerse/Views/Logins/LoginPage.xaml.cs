// LoginPage.xaml.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using System.Collections.Generic;
using MedicsVerse.Views.Base;
using MedicsVerse.Views.Registers;
using Xamarin.Forms;

namespace MedicsVerse.Views.Logins
{
    public partial class LoginPage : BasePreLogin
    {
        public LoginPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        void ButtonGoogle_Tapped(System.Object sender, System.EventArgs e)
        {
        }

        void ButtonFacebook_Tapped(System.Object sender, System.EventArgs e)
        {
        }

        void SignInButton_Tapped(System.Object sender, System.EventArgs e)
        {
        }

        void RegisterButton_Tapped(System.Object sender, System.EventArgs e)
        {
            RegistrationPage page = new RegistrationPage();
            Application.Current.MainPage = new NavigationPage(page);
        }
    }
}

