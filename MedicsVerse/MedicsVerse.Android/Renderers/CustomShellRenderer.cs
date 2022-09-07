// CustomShellRenderer.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
using Android.Graphics;
using Android.Util;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.DrawerLayout.Widget;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Tabs;
using System.ComponentModel;
using MedicsVerse.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;

using Application = Android.App.Application;
using Android.Content.Res;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace MedicsVerse.Droid.Renderers
{
    public class CustomShellRenderer : ShellRenderer
    {
        public CustomShellRenderer(Context context) : base(context)
        {
        }

        protected override IShellTabLayoutAppearanceTracker CreateTabLayoutAppearanceTracker(ShellSection shellSection)
        {
            return new MyShellTabLayoutAppearanceTracker(this);
        }

        protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker()
        {
            return new MyShellToolbarAppearanceTracker(this);
        }

        protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
        {
            return new CustomBottomNavView();
        }
    }

    public class MyShellToolbarAppearanceTracker : IShellToolbarAppearanceTracker
    {
        private CustomShellRenderer myShellRenderer;
        AndroidX.AppCompat.Widget.Toolbar _toolbar;

        public MyShellToolbarAppearanceTracker(CustomShellRenderer myShellRenderer)
        {
            this.myShellRenderer = myShellRenderer;
        }

        public void Dispose()
        { }

        public void ResetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker)
        {
            Context context = Application.Context;
            for (int index = 0; index < toolbar.ChildCount; index++)
            {
                if (toolbar.GetChildAt(index) is TextView)
                {
                    var title = toolbar.GetChildAt(index) as TextView;
                    //Change the following code to change the font size of the Header title.
                    title.SetTextSize(ComplexUnitType.Sp, 18);

                    title.TextSize = 18;
                    title.TextAlignment = Android.Views.TextAlignment.Center;
                    title.Gravity = Android.Views.GravityFlags.Center;
                    //Typeface face = Typeface.CreateFromAsset(context.Resources.Assets, "trasandinamedium.otf");
                    //title.SetTypeface(face, TypefaceStyle.Normal);

                    toolbar.SetTitleMargin(MainActivity.displayMetrics.WidthPixels / 4 - Convert.ToInt32(title.TextSize) - title.Text.Length / 2, 0, 0, 0);
                }
            }
        }

        public void SetAppearance(AndroidX.AppCompat.Widget.Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
        {
            _toolbar = toolbar;
            Context context = Application.Context;

            for (int index = 0; index < toolbar.ChildCount; index++)
            {
                if (toolbar.GetChildAt(index) is TextView)
                {
                    var title = toolbar.GetChildAt(index) as TextView;
                    //Change the following code to change the font size of the Header title.
                    title.SetTextSize(ComplexUnitType.Sp, 18);

                    title.TextSize = 18;
                    title.TextAlignment = Android.Views.TextAlignment.Center;
                    title.Gravity = Android.Views.GravityFlags.Center;
                    //Typeface face = Typeface.CreateFromAsset(context.Resources.Assets, "trasandinamedium.otf");
                    //title.SetTypeface(face, TypefaceStyle.Normal);

                    toolbar.SetTitleMargin(MainActivity.displayMetrics.WidthPixels / 4 - Convert.ToInt32(title.TextSize) - title.Text.Length / 2, 0, 0, 0);
                }
            }
        }
    }

    public class MyShellTabLayoutAppearanceTracker : IShellTabLayoutAppearanceTracker
    {
        private CustomShellRenderer myShellRenderer;

        public MyShellTabLayoutAppearanceTracker(CustomShellRenderer myShellRenderer)
        {
            this.myShellRenderer = myShellRenderer;
        }

        public void Dispose()
        {
        }

        public void ResetAppearance(TabLayout tabLayout)
        { }

        public void SetAppearance(TabLayout tabLayout, ShellAppearance appearance)
        {
            try
            {
                Context context = Application.Context;
                tabLayout.SetBackgroundColor(Android.Graphics.Color.White);

                int textColor = ContextCompat.GetColor(context, Resource.Color.colorPrimary);
                int selectedTextColor = ContextCompat.GetColor(context, Resource.Color.colorAccent);

                tabLayout.SetTabTextColors(textColor, selectedTextColor);

                tabLayout.TabMode = TabLayout.ModeFixed;
                tabLayout.TabGravity = TabLayout.GravityFill;
            }
            catch (Exception ex)
            {

            }
        }
    }

    public class CustomBottomNavView : IShellBottomNavViewAppearanceTracker
    {
        public void Dispose()
        {
        }
        public void ResetAppearance(BottomNavigationView bottomView)
        {
        }
        public void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            bottomView.ItemIconTintList = null;

            int[][] states = new int[][]
             {
                // disabled
                new int[] {-Android.Resource.Attribute.StateChecked}, // unchecked
                new int[] { Android.Resource.Attribute.StateChecked }  // pressed
             };
            int[] colors = new int[]
            {
                ((Xamarin.Forms.Color) Xamarin.Forms.Application.Current.Resources["LightGray"]).ToAndroid(),
                ((Xamarin.Forms.Color) Xamarin.Forms.Application.Current.Resources["Accent"]).ToAndroid()
            };
            ColorStateList colorStateList = new ColorStateList(states, colors);
            bottomView.ItemIconTintList = colorStateList;
            bottomView.ItemTextColor = colorStateList;

            bottomView.SetBackgroundColor(Android.Graphics.Color.White);
            bottomView.SetShiftMode(false, false); //stop items from shifting
        }
    }
}

