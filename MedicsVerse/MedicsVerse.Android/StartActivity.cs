// StartActivity.cs
// Author:  benitkibabu 
// Date: 05/09/2022

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.SplashScreen;

namespace MedicsVerse.Droid
{
    [Activity(Name = "com.cedricm.medicsverse.StartActivity", Label = "MedicsVerse",
        Icon = "@mipmap/ic_launcher", Theme = "@style/Theme.SplashTheme",
        MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation |
        ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class StartActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SplashScreen splashScreen = AndroidX.Core.
                SplashScreen.SplashScreen.InstallSplashScreen(this);
        }

        protected override void OnResume()
        {
            try
            {
                base.OnResume();
                var intent = new Intent(this, typeof(MainActivity));
                if (intent.Extras != null)
                {
                    intent.PutExtras(Intent.Extras);
                }

                StartActivity(intent);
                Finish();
            }
            catch (Exception ex) { }
        }
    }
}

