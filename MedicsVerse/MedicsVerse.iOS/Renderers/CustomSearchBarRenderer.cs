// CustomSearchBarRenderer.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
using CoreAnimation;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using MedicsVerse.iOS.Renderers;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace MedicsVerse.iOS.Renderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            try
            {
                if (Control != null && Control is UISearchBar tv)
                {
                    //Control.BorderStyle = UITextBorderStyle.None;

                    Control.BackgroundColor = Element.BackgroundColor.ToUIColor();//UIColor.Clear;
                    Control.Layer.CornerRadius = 20;
                    //Control.TextColor = Element.TextColor.ToUIColor();///UIColor.White;
                    Control.Layer.MasksToBounds = false;

                    Control.Layer.ShadowColor = UIColor.White.CGColor;
                    Control.Layer.ShadowOffset = new CoreGraphics.CGSize(0.0f, 0.1f);
                    Control.Layer.ShadowRadius = 0.0f;
                    Control.Layer.ShadowOpacity = 0.0f;

                    var bottomBorder = new CALayer();
                    bottomBorder.Frame = new CoreGraphics.CGRect(0.0f, Frame.Height - Element.Height, Frame.Width, 1.0f);
                    bottomBorder.BorderColor = UIColor.White.CGColor;
                    bottomBorder.BorderWidth = 1.0f;
                    //Control.Layer.AddSublayer(bottomBorder);
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}

