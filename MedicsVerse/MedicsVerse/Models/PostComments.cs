// PostComments.cs
// Author:  benitkibabu 
// Date: 07/09/2022
using System;
namespace MedicsVerse.Models
{
    public class PostComments
    {
        public long CommentId { get; set; }
        public long PostId { get; set; }
        public string Text { get; set; }
        public DateTime DateCommented { get; set; }

    }
}

