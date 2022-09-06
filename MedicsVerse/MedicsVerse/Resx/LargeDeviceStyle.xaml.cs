// LargeDeviceStyle.xaml.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MedicsVerse.Resx
{
    public partial class LargeDeviceStyle : ResourceDictionary
    {
        public static LargeDeviceStyle SharedInstance { get; } = new LargeDeviceStyle();

        public LargeDeviceStyle()
        {
            InitializeComponent();
        }
    }
}

