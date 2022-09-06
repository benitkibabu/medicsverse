// CustomEntryRenderer.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using CoreAnimation;
using MedicsVerse.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace MedicsVerse.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            try
            {
                if (Control != null && Control is UITextField tv)
                {
                    Control.BorderStyle = UITextBorderStyle.None;

                    Control.BackgroundColor = Element.BackgroundColor.ToUIColor();//UIColor.Clear;
                    Control.Layer.CornerRadius = 1;
                    Control.TextColor = Element.TextColor.ToUIColor();///UIColor.White;
                    Control.Layer.MasksToBounds = false;

                    Control.Layer.ShadowColor = UIColor.White.CGColor;
                    Control.Layer.ShadowOffset = new CoreGraphics.CGSize(0.0f, 0.1f);
                    Control.Layer.ShadowRadius = 0.0f;
                    Control.Layer.ShadowOpacity = 1.0f;

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

