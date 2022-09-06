// CustomLabelRenderer.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Android.Content;
using Android.Text;
using Android.Widget;
using MedicsVerse.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Label), typeof(CustomLabelRenderer))]//, new[] { typeof(VisualMarker.MaterialVisual) })]
namespace MedicsVerse.Droid.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer(Context context) : base(context)
        {
            //AutoPackage = false;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text))
            {
                try
                {
                    UpdateUIElement();
                }
                catch (Exception ex)
                {
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                try
                {
                    UpdateUIElement();
                }
                catch (Exception ex)
                {
                }

            }
        }

        private void UpdateUIElement()
        {
            if (!string.IsNullOrEmpty(Element.Text) && Regex.Match(Element.Text, "<.*?>").Success)
            {
                ISpanned spannedText = GetSpannedText(Element.Text);

                Control?.SetText(spannedText, TextView.BufferType.Spannable);
            }
            else
            {
                Control?.SetText(Element.Text, TextView.BufferType.Normal);
            }
        }

        /// <summary>
        /// Method to format Html strings into presentable text
        /// </summary>
        /// <param name="htmlText"></param>
        /// <returns></returns>
        private ISpanned GetSpannedText(string htmlText)
        {

            ISpanned spannedText;

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.N)
            {
                spannedText = Html.FromHtml(htmlText, FromHtmlOptions.ModeLegacy);
            }
            else
            {
#pragma warning disable CS0618 // Type or member is obsolete
                spannedText = Html.FromHtml(htmlText);
#pragma warning restore CS0618 // Type or member is obsolete
            }

            return spannedText;

        }
    }
}

