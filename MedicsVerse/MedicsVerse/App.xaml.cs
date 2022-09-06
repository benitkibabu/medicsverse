using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MedicsVerse.Views;
using MedicsVerse.Views.Home;
using MedicsVerse.Resx;
using System.Collections.Generic;
using Xamarin.Essentials;
using MedicsVerse.Views.Logins;

namespace MedicsVerse
{
    public partial class App : Application
    {
        public static App Instance
        {
            get => (App)Current;
        }

        public App()
        {
            InitializeComponent();

            LoadStyles();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        /// <summary>
        /// Determine if the device is a small device
        /// </summary>
        /// <returns></returns>
        private bool IsASmallDevice()
        {
            int smallWidthRes = 750;
            int smallHeightRes = 1334;
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = (int)mainDisplayInfo.Width;

            // Height (in pixels)
            var height = (int)mainDisplayInfo.Height;
            return (width <= smallWidthRes && height <= smallHeightRes);
        }

        /// <summary>
        /// Determine if current device is large display device
        /// </summary>
        /// <returns></returns>
        private bool IsALargeDevice()
        {
            int largeHeightRes = 2280;
            int largeWidthtRes = 1080;
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = (int)mainDisplayInfo.Width;

            // Height (in pixels)
            var height = (int)mainDisplayInfo.Height;

            return (width >= largeWidthtRes && height >= largeHeightRes);
        }

        /// <summary>
        /// Method to Load different Styles depending on Devices size
        /// </summary>
        private void LoadStyles()
        {
            if (IsASmallDevice())
            {
                dictionary.MergedDictionaries.Add(SmallDeviceStyle.SharedInstance);
            }
            else if (IsALargeDevice())
            {
                dictionary.MergedDictionaries.Add(LargeDeviceStyle.SharedInstance);
            }
            else
            {
                dictionary.MergedDictionaries.Add(GeneralDeviceStyle.SharedInstance);
            }
        }
    }
}

