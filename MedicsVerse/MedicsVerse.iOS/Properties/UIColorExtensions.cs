// UIColorExtensions.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
using UIKit;

namespace MedicsVerse.iOS.Properties
{
    public class UIColorExtensions
    {
        protected UIColorExtensions()
        {
        }

        /// <summary>
        /// Convert Hex String color code to UIColor
        /// </summary>
        /// <param name="hexValue"></param>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public static UIColor FromHexString(string hexValue, float alpha = 1.0f)
        {
            try
            {
                var colorString = hexValue.Replace("#", "");
                if (alpha > 1.0f)
                {
                    alpha = 1.0f;
                }
                else if (alpha < 0.0f)
                {
                    alpha = 0.0f;
                }

                float red, green, blue;

                switch (colorString.Length)
                {
                    case 3: // #RGB
                        {
                            red = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(0, 1)), 16) / 255f;
                            green = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(1, 1)), 16) / 255f;
                            blue = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(2, 1)), 16) / 255f;
                            return UIColor.FromRGBA(red, green, blue, alpha);
                        }

                    case 4: // #RGBA
                        {
                            red = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(0, 1)), 16) / 255f;
                            green = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(1, 1)), 16) / 255f;
                            blue = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(2, 1)), 16) / 255f;
                            alpha = Convert.ToInt32(string.Format("{0}{0}", colorString.Substring(3, 1)), 16) / 255f;
                            return UIColor.FromRGBA(red, green, blue, alpha);
                        }
                    case 6: // #RRGGBB
                        {
                            red = Convert.ToInt32(colorString.Substring(0, 2), 16) / 255f;
                            green = Convert.ToInt32(colorString.Substring(2, 2), 16) / 255f;
                            blue = Convert.ToInt32(colorString.Substring(4, 2), 16) / 255f;
                            return UIColor.FromRGBA(red, green, blue, alpha);
                        }
                    case 8: // #RRGGBBAA
                        {
                            red = Convert.ToInt32(colorString.Substring(0, 2), 16) / 255f;
                            green = Convert.ToInt32(colorString.Substring(2, 2), 16) / 255f;
                            blue = Convert.ToInt32(colorString.Substring(4, 2), 16) / 255f;
                            alpha = Convert.ToInt32(colorString.Substring(6, 2), 16) / 255f;
                            return UIColor.FromRGBA(red, green, blue, alpha);
                        }

                    default:
                        return UIColor.Black;

                }
            }
            catch (Exception ex)
            {
                return UIColor.Black;
            }
        }
    }
}

