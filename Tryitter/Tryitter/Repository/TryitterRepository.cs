using System;
using Tryitter.Models;


namespace Tryitter.Repository
{
   public class TryitterRepository : ITryitterRepository
    {
        private readonly IContext _context;
        public TryitterRepository(IContext context)
        {
            _context = context;

        }
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList<User>();
        }
        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList<Post>();
        }
        public void AddUser( User user)
        {
            _context.Users.Add(user);
        }
    }
}

