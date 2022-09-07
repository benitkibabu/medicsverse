// CustomShellRenderer.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
using CoreGraphics;
using Foundation;
using static Xamarin.Forms.Platform.iOS.ShellSectionRootHeader;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using MedicsVerse.iOS.Renderers;
using Xamarin.Forms;
using MedicsVerse.iOS.Properties;

[assembly: ExportRenderer(typeof(Shell), typeof(CustomShellRenderer))]
namespace MedicsVerse.iOS.Renderers
{
    public class CustomShellRenderer : ShellRenderer
    {
        protected override IShellSectionRenderer CreateShellSectionRenderer(ShellSection shellSection)
        {
            var shellSectionRenderer = new CustomShellSectionRenderer(this);
            return shellSectionRenderer;
        }
        protected override IShellNavBarAppearanceTracker CreateNavBarAppearanceTracker()
        {
            return new MyNavBarAppearance();
        }

        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new CustomTabbarAppearance();
        }
    }

    public class CustomTabbarAppearance : IShellTabBarAppearanceTracker
    {
        public void Dispose()
        {
        }

        public void ResetAppearance(UITabBarController controller)
        {
        }

        UIView myView = null;
        public void SetAppearance(UITabBarController controller, ShellAppearance appearance)
        {
            UITabBar myTabBar = controller.TabBar;
            UIColor tabBarColor = ((Xamarin.Forms.Color)Xamarin.Forms.Application.Current.Resources["White"]).ToUIColor();

            if (myTabBar != null)
            {
                //Top border for bottom nav
                myView = new UIView(new CGRect(0, 0, myTabBar.Frame.Width, 2))
                {
                    BackgroundColor = ((Xamarin.Forms.Color)Xamarin.Forms.Application.Current.Resources["LighterGray"]).ToUIColor()
                };
                myTabBar.AddSubview(myView);

                myTabBar.BackgroundColor = tabBarColor;
                myTabBar.BarTintColor = tabBarColor;
                myTabBar.Translucent = false;

                myTabBar.SelectedImageTintColor = ((Xamarin.Forms.Color)Xamarin.Forms.Application.Current.Resources["Accent"]).ToUIColor();
                myTabBar.UnselectedItemTintColor = ((Xamarin.Forms.Color)Xamarin.Forms.Application.Current.Resources["LightGray"]).ToUIColor();


                if (myTabBar.Items != null)
                {
                    foreach (UITabBarItem item in myTabBar.Items)
                    {
                        item.Title = item.Title;
                        item.ImageInsets = new UIEdgeInsets(0, 0, 0, 0);
                    }
                }
            }
        }

        public void UpdateLayout(UITabBarController controller)
        { }

    }

    public class CustomShellSectionRenderer : ShellSectionRenderer
    {
        public CustomShellSectionRenderer(IShellContext context) : base(context)
        { }

        protected override IShellSectionRootRenderer CreateShellSectionRootRenderer(ShellSection shellSection, IShellContext shellContext)
        {
            var renderer = new CustomShellSectionRootRenderer(shellSection, shellContext);

            return renderer;
        }
    }

    public class CustomShellSectionRootRenderer : ShellSectionRootRenderer
    {
        public CustomShellSectionRootRenderer(ShellSection section, IShellContext context) : base(section, context)
        { }

        protected override IShellSectionRootHeader CreateShellSectionRootHeader(IShellContext shellContext)
        {
            var renderer = new CustomShellSectionRootHeader(shellContext);
            return renderer;
        }
    }

    public class CustomShellSectionRootHeader : ShellSectionRootHeader
    {
        public CustomShellSectionRootHeader(IShellContext context) : base(context)
        { }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            this.View.Bounds = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Size.Width, 60);
            this.View.BackgroundColor = UIColor.White;
            var cell = base.GetCell(collectionView, indexPath) as ShellSectionHeaderCell;

            UIView view = new UIView(new CGRect(0, 6, UIScreen.MainScreen.Bounds.Size.Width, 40));
            view.BackgroundColor = UIColor.White;
            collectionView.BackgroundView = view;

            collectionView.Bounds = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Size.Width, 40);

            var layout = new UICollectionViewFlowLayout();
            layout.ItemSize = new CGSize(cell.Frame.Width, cell.Frame.Height);
            layout.MinimumInteritemSpacing = UIScreen.MainScreen.Bounds.Size.Width / 8;
            layout.SectionInset = new UIEdgeInsets(top: 8,
                left: UIScreen.MainScreen.Bounds.Size.Width / 8,
                bottom: 0,
                right: UIScreen.MainScreen.Bounds.Size.Width / 8);

            collectionView.CollectionViewLayout = layout;

            return cell;
        }
    }


    public class CustomUICollectionViewFlowLayout : UICollectionViewFlowLayout
    {
        public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
        {
            return base.LayoutAttributesForElementsInRect(rect);
        }
    }

    internal class MyNavBarAppearance : IShellNavBarAppearanceTracker
    {
        public void Dispose()
        { }

        public void ResetAppearance(UINavigationController controller)
        { }

        public void SetAppearance(UINavigationController controller, ShellAppearance appearance)
        {
            UIColor tintColor = UIColorExtensions.FromHexString("#33b960", 1.0f);

            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                var app = new UINavigationBarAppearance();
                app.ConfigureWithOpaqueBackground();
                app.BackgroundImage = new UIImage().ApplyTintColor(UIColor.Clear);
                app.BackgroundColor = tintColor;
                app.ShadowColor = UIColor.Clear;
                app.ShadowImage = new UIImage().ApplyTintColor(UIColor.Clear);

                app.TitleTextAttributes = new UIStringAttributes()
                {
                    ForegroundColor = UIColor.White
                };
                controller.NavigationBar.TintColor = UIColor.White;
                controller.NavigationBar.StandardAppearance = app;
                controller.NavigationBar.CompactAppearance = app;
                controller.NavigationBar.ScrollEdgeAppearance = app;
            }
            else
            {
                controller.NavigationBar.BarTintColor = tintColor;
                controller.NavigationBar.TintColor = UIColor.White;
                controller.NavigationBar.Translucent = false;
                controller.NavigationBar.SetBackgroundImage(new UIImage(), UIBarPosition.Any, UIBarMetrics.Default);
                controller.NavigationBar.ShadowImage = new UIImage();
                controller.NavigationBar.TitleTextAttributes = new UIStringAttributes()
                {
                    ForegroundColor = UIColor.White
                };
            }
        }

        public void SetHasShadow(UINavigationController controller, bool hasShadow)
        { }

        public void UpdateLayout(UINavigationController controller)
        { }
    }
}

