using System;
namespace Tryitter.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string email { get; set; } = null!;
        public IEnumerable<Post> Posts { get; set; } = new List<Post>(); 
    }
}