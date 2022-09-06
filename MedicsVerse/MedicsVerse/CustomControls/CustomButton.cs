// CustomButton.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using Xamarin.Forms;

namespace MedicsVerse.CustomControls
{
    public class CustomButton : Button
    {
        public static new readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CustomButton), typeof(CornerRadius),
                typeof(CustomButton));
        public CustomButton()
        {
            // MK Clearing default values (e.g. on iOS it's 5)
            base.CornerRadius = 0;
        }

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}

