// Post.cs
// Author:  benitkibabu 
// Date: 06/09/2022
using System;
namespace MedicsVerse.Models
{
    public class Post
    {
        public long PostId { get; set; }
        public string Title { get; set; }
        public string PostImageUrl { get; set; }
        public string PostBody { get; set; }
        public DateTime DateCreated { get; set; }
        public User User { get; set; }
    }
}

