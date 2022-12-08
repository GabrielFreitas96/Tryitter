using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tryitter.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Content { get; set; } = null!;
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}

