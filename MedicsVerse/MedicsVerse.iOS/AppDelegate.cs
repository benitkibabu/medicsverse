using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MedicsVerse.iOS.Properties;
using UIKit;

namespace MedicsVerse.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            try
            {
                UIColor tintColor = UIColorExtensions.FromHexString("#33b960", 1.0f);

                //Changes with iOS 13 or above
                if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
                {

                    var appearance = new UINavigationBarAppearance();
                    appearance.ConfigureWithOpaqueBackground();
                    appearance.BackgroundImage = new UIImage().ApplyTintColor(UIColor.Clear);
                    appearance.BackgroundColor = tintColor;
                    appearance.ShadowColor = UIColor.Clear;
                    appearance.ShadowImage = new UIImage().ApplyTintColor(UIColor.Clear);

                    appearance.TitleTextAttributes = new UIStringAttributes()
                    {
                        ForegroundColor = UIColor.White
                    };

                    UINavigationBar.Appearance.StandardAppearance = appearance;
                    UINavigationBar.Appearance.CompactAppearance = UINavigationBar.Appearance.StandardAppearance;
                    UINavigationBar.Appearance.ScrollEdgeAppearance = UINavigationBar.Appearance.StandardAppearance;
                }
                else
                {
                    UINavigationBar.Appearance.BarTintColor = tintColor;
                    UINavigationBar.Appearance.TintColor = UIColor.Gray;
                    UINavigationBar.Appearance.Translucent = false;
                    UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarPosition.Any, UIBarMetrics.Default);
                    UINavigationBar.Appearance.ShadowImage = new UIImage();
                    UINavigationBar.Appearance.TitleTextAttributes = new UIStringAttributes()
                    {
                        ForegroundColor = UIColor.White
                    };
                }

                var attribute = new UITextAttributes();
                attribute.TextColor = UIColor.Clear;
                UIBarButtonItem.Appearance.SetTitleTextAttributes(attribute, UIControlState.Normal);
                UIBarButtonItem.Appearance.SetTitleTextAttributes(attribute, UIControlState.Highlighted);

                UITabBar.Appearance.BackgroundImage = new UIImage();
                UITabBar.Appearance.BackgroundColor = tintColor;
                UITabBar.Appearance.ShadowImage = new UIImage();

                UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
            }
            catch (Exception ex) { }

            return base.FinishedLaunching(app, options);
        }
    }
}

