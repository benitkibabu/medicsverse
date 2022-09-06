using System;
using System.Collections.Generic;
using MedicsVerse.ViewModels;
using MedicsVerse.Views;
using Xamarin.Forms;

namespace MedicsVerse.Views.Home
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}

