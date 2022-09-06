// CustomButtonRenderer.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using System.ComponentModel;
using MedicsVerse.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
namespace MedicsVerse.iOS.Renderers
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            try
            {
                if (Control != null && Control is UIButton button)
                {
                    button.TitleLabel.TextAlignment = UITextAlignment.Center;
                    button.LineBreakMode = GetMode(LineBreakMode.WordWrap);
                }

                if (Element is Button view)
                {
                    Paint(view);
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            try
            {
                if (Control != null && Control is UIButton button)
                {
                    button.TitleLabel.TextAlignment = UITextAlignment.Center;
                }

                if (Element is Button view)
                {
                    Paint(view);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Paint(Button view)
        {
            this.Layer.CornerRadius = (float)view.CornerRadius;
            this.Layer.BorderColor = view.BorderColor.ToCGColor();
            this.Layer.BackgroundColor = view.BackgroundColor.ToCGColor();
            this.Layer.BorderWidth = (int)view.BorderWidth;

            this.Layer.ShadowOpacity = 1.0f;
            this.Layer.ShadowRadius = 0.0f;
            this.Layer.MasksToBounds = false;
            this.Layer.ShadowOffset = CoreGraphics.CGSize.Empty;
            this.Layer.ShadowColor = UIColor.Clear.CGColor;
        }

        private UILineBreakMode GetMode(LineBreakMode line)
        {
            switch (line)
            {
                case LineBreakMode.CharacterWrap:
                    return UILineBreakMode.CharacterWrap;
                case LineBreakMode.HeadTruncation:
                    return UILineBreakMode.HeadTruncation;
                case LineBreakMode.MiddleTruncation:
                    return UILineBreakMode.MiddleTruncation;
                case LineBreakMode.TailTruncation:
                    return UILineBreakMode.TailTruncation;
                default:
                    return UILineBreakMode.WordWrap;

            }
        }
    }
}

