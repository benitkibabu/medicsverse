// GeneralDeviceStyle.xaml.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MedicsVerse.Resx
{
    public partial class GeneralDeviceStyle : ResourceDictionary
    {
        public static GeneralDeviceStyle SharedInstance { get; } = new GeneralDeviceStyle();

        public GeneralDeviceStyle()
        {
            InitializeComponent();
        }
    }
}

