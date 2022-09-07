// Post.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
using MedicsVerse.Utils;

namespace MedicsVerse.Models
{
    public class Post
    {
        public long PostId { get; set; }
        public string PostImageUrl { get; set; }
        public string PostBody { get; set; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }


        public string PostDateToDisplay
        {
            get { return DateTimeFormatter.GetDateTimeString(DateCreated); }
        }

        public static Post Post1()
        {
            return new Post()
            {
                PostId = 1,
                User = User.GetUser1(),
                PostBody = "Learning 3D as a product designer",
                DateCreated = DateTime.Now,
                PostImageUrl = "https://www.pluralsight.com/content/dam/pluralsight/blog/thumbnails/dt/2014/06/the-industrial-design-process-part-4-taking-2d-concept-designs-into-the-3d-world/cover.jpg"
            };
        }

        public static Post Post2()
        {
            return new Post()
            {
                PostId = 1,
                User = User.GetUser2(),
                PostBody = "I am happy to share that I will be joining x company as a researcher",
                DateCreated = DateTime.Now.AddDays(-2),
                PostImageUrl = "https://blogs.autodesk.com/sketchbookpro/wp-content/uploads/sites/133/2019/03/Sewing_Machine_Render-1024x724.jpg"
            };
        }
    }
}

