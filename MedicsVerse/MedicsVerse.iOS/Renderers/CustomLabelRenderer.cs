// CustomLabelRenderer.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using Foundation;
using System.ComponentModel;
using System.Text.RegularExpressions;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace MedicsVerse.iOS.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text) && Element.TextType == TextType.Html)
            {
                UpdateTextOnControl();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Label.TextProperty.PropertyName)
            {
                if (Control != null && Element != null && !string.IsNullOrWhiteSpace(Element.Text) && Element.TextType == TextType.Html)
                {
                    UpdateTextOnControl();
                }
            }
        }

        /// <summary>
        /// Method to update text display on the UI control
        /// </summary>
        private void UpdateTextOnControl()
        {
            try
            {
                string fontName = Element.FontFamily;
                nfloat fontSize = (nfloat)Element.FontSize;
                var lineHeight = (Element.LineHeight == 0 || Element.LineHeight == 0.0) ? 1.0f : (nfloat)Element.LineHeight;

                //If a font name was not specified, use this default name instead
                if (string.IsNullOrEmpty(fontName))
                {
                    fontName = "TrasandinaMedium";
                }

                UIFont font = UIFont.FromName(fontName, fontSize);
                var attributedString = new NSMutableAttributedString();

                var html = $"<span style=\"font-family:'{fontName}'; line-height:{lineHeight}; font-size: {fontSize}\">{Element.Text}</span>";
                NSData data = NSData.FromString(html, NSStringEncoding.UTF8);
                var attributes = new NSAttributedStringDocumentAttributes();
                attributes.DocumentType = NSDocumentType.HTML;
                attributes.StringEncoding = NSStringEncoding.UTF8;

                var error = new NSError();
                var htmlString = new NSAttributedString(html, attributes, ref error);

                attributedString.Append(htmlString);

                Control.Lines = 0;
                Control.AttributedText = htmlString;
                Control.TextAlignment = GetAlignment(Element.HorizontalTextAlignment);
                Control.TextColor = Element.TextColor.ToUIColor();

                Control.LineBreakMode = GetMode(Element.LineBreakMode);
                Control.Lines = Element.MaxLines;

                if (Element.TextTransform == TextTransform.Uppercase)
                {
                    Control.Text = Control.Text.ToUpper();
                }
            }
            catch (Exception ex)
            {
            }
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

        /// <summary>
        /// Method to construct an attributed string that has bold text
        /// </summary>
        /// <param name="originalText">Origin String value</param>
        /// <param name="font">Origin Font value</param>
        /// <returns>Returns a NSMutableAttributedString</returns>
        private void AddBoldAttributedString(string originalText, UIFont font, NSMutableAttributedString attributedString)
        {
            var startIndex = GetStartIndex(originalText, "<b>");
            var endIndex = GetEndIndex(originalText, "</b>");

            var boldString = new NSString(originalText.Substring(startIndex, endIndex - startIndex));

            var updatedString = StripHTML(originalText);
            var range = new NSString(updatedString).LocalizedStandardRangeOfString(boldString);
            var boldFontAttributes = new UIStringAttributes
            {
                Font = UIFont.BoldSystemFontOfSize(font.PointSize)
            };

            attributedString.AddAttributes(boldFontAttributes.Dictionary, range);
        }


        /// <summary>
        /// Remove all html tags from the string (Do not use if parsing external HTML content
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        /// <summary>
        /// Method to convert Xaml Forms Text Alignement to UITextAlignment
        /// </summary>
        /// <param name="textAlignment"></param>
        /// <returns></returns>
        private UITextAlignment GetAlignment(TextAlignment textAlignment)
        {

            switch (textAlignment)
            {
                case TextAlignment.Center: return UITextAlignment.Center;
                case TextAlignment.Start: return UITextAlignment.Left;
                case TextAlignment.End: return UITextAlignment.Right;
                default: return UITextAlignment.Natural;
            }
        }

        private int GetStartIndex(string labelString, string htmlPattern)
        {
            return labelString.IndexOf(htmlPattern) + htmlPattern.Length;
        }

        private int GetEndIndex(string labelString, string htmlPattern)
        {
            return labelString.IndexOf(htmlPattern);
        }
    }
}

