// RegistrationPage.xaml.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using System.Collections.Generic;
using MedicsVerse.Views.Base;
using MedicsVerse.Views.Logins;
using Xamarin.Forms;

namespace MedicsVerse.Views.Registers
{
    public partial class RegistrationPage : BasePreLogin
    {
        public RegistrationPage()
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

        void LogInButton_Tapped(System.Object sender, System.EventArgs e)
        {
            LoginPage page = new LoginPage();
            Application.Current.MainPage = new NavigationPage(page);
        }

        void SignUpButton_Tapped(System.Object sender, System.EventArgs e)
        {
        }
    }
}

