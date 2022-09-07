// User.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
namespace MedicsVerse.Models
{
    public class User
    {
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string ImageUrl { get; set; }
        public string Rank { get; set; }

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
                    var words = FullName.Split(' ');
                    if (words.Length > 1)
                    {
                        return $"{words[0].Substring(0, 1)}" +
                        $"{words[1].Substring(0, 1)}";
                    }
                    else
                    {
                        return FullName.Substring(0, 1);
                    }
                }
            }
        }

        public static User GetUser1()
        {
            return new User()
            {
                FullName = "Mark Testing",
                JobTitle = "Product Designer",
                Rank = ". 3rd",
                ImageUrl = "https://cachedimages.podchaser.com/256x256/aHR0cHM6Ly9jcmVhdG9yLWltYWdlcy5wb2RjaGFzZXIuY29tLzBmMWRmZDM4NGY1YzM3OWFlNTJiZWE1ZjE0MzNkZWFjLmpwZWc%3D/aHR0cHM6Ly93d3cucG9kY2hhc2VyLmNvbS9pbWFnZXMvbWlzc2luZy1pbWFnZS5wbmc%3D"
            };
        }

        public static User GetUser2()
        {
            return new User()
            {
                FullName = "Jay Test",
                JobTitle = "UX Researcher",
                Rank = ". 3rd",
                ImageUrl = "https://news.artnet.com/app/news-upload/2021/06/SNY-Portrait-of-JAY-Z-by-Raven-B.-Varona-copy-256x256.jpg"
            };
        }
    }
}

