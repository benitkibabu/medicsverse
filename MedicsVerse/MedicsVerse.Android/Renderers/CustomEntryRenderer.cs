// CustomEntryRenderer.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using MedicsVerse.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]//, new[] { typeof(VisualMarker.MaterialVisual) })]
namespace MedicsVerse.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control?.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
            Control?.SetTextColor(Element.TextColor.ToAndroid());

            if (Control != null)
            {
                if (Element is Entry et)
                {
                    Control?.SetHintTextColor(ColorStateList.ValueOf(et.PlaceholderColor.ToAndroid()));

                    //Set the border line color
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                        Control.BackgroundTintList = ColorStateList.ValueOf(et.PlaceholderColor.ToAndroid());
                    else
                        Control.Background.SetColorFilter(et.PlaceholderColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                }
            }
        }
    }
}

