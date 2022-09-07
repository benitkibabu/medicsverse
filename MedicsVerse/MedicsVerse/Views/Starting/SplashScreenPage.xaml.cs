// SplashScreenPage.xaml.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
using System.Collections.Generic;
using MedicsVerse.Views.Base;
using MedicsVerse.Views.Logins;
using Xamarin.Forms;

namespace MedicsVerse.Views.Starting
{
    public partial class SplashScreenPage : BasePreLogin
    {
        public SplashScreenPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    LoadLoginPage();
                });
                return false;
            });
        }

        private void LoadLoginPage()
        {
            LoginPage page = new LoginPage();
            Application.Current.MainPage = new NavigationPage(page);
        }
    }
}

