﻿// SmallDeviceStyle.xaml.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MedicsVerse.Resx
{
    public partial class SmallDeviceStyle : ResourceDictionary
    {
        public static SmallDeviceStyle SharedInstance { get; } = new SmallDeviceStyle();

        public SmallDeviceStyle()
        {
            InitializeComponent();
        }
    }
}

