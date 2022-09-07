// User.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
namespace MedicsVerse.Models
{
    public class User
    {
        public string FullName { get; set; }
        public string ImageUrl { get; set; }


        public string Initials
        {
            get
            {
                if (string.IsNullOrEmpty(FullName))
                {
                    return "";
                }
                else
                {
                    if (FullName.Split(' ').Length > 1)
                    {
                        return $"{FullName.Substring(0, 1)}" +
                        $"{FullName.Substring(FullName.IndexOf(" " + 1, 1))}";
                    }
                    else
                    {
                        return FullName.Substring(0, 1);
                    }
                }
            }
        }
    }
}

