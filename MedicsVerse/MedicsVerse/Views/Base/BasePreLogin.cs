// BasePreLogin.cs
// Author:  benitkibabu 
// Date: 05/09/2022
using System;
using Xamarin.Forms;

namespace MedicsVerse.Views.Base
{
    public class BasePreLogin : ContentPage
    {
        private DateTime LastTimeBtnClicked;

        public BasePreLogin()
        {
        }

        /// <summary>
        /// Check to see if we can click the button (To prevent double clicking in quick succession)
        /// </summary>
        public bool IsButtonClickable
        {
            get
            {
                if (LastTimeBtnClicked == null)
                {
                    LastTimeBtnClicked = DateTime.Now;
                    return true;
                }

                var time = DateTime.Now.Subtract(LastTimeBtnClicked).Milliseconds;

                if (time < 120)
                {
                    return false;
                }

                LastTimeBtnClicked = DateTime.Now;

                return true;
            }
        }
    }
}

