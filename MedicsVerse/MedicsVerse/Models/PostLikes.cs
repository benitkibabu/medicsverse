// PostLikes.cs
// Author:  benitkibabu 
// Date: 07/09/2022
using System;
namespace MedicsVerse.Models
{
    public class PostLikes
    {
        public long LikesId { get; set; }
        public long PostId { get; set; }
        public DateTime DateLiked { get; set; }
    }
}

