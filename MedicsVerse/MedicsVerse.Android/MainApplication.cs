// MainApplication.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using Android.App;
using Android.Runtime;

namespace MedicsVerse.Droid
{
    [Application(Debuggable = true, Name = "com.cedricm.medicsverse.MainApplication")]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        { }

        public override void OnCreate()
        {
            base.OnCreate();

            try
            { //FirebaseApp.InitializeApp(this);
            }
            catch (Exception) { }
        }
    }
}

