// CustomSearchViewRenderer.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
using Android.Content.Res;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using MedicsVerse.Droid.Renderers;
using Android.Content;

[assembly: ExportRenderer(typeof(SearchBar), typeof(CustomSearchViewRenderer))]
namespace MedicsVerse.Droid.Renderers
{
    public class CustomSearchViewRenderer : SearchBarRenderer
    {
        public CustomSearchViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            try
            {
                var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                var plate = Control.FindViewById(plateId);
                plate.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
            catch (Exception ex)
            {
            }
        }
    }
}

