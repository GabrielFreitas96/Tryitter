using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        public User? GetUser(int id)
        {
            return _context.Users.Find(id);
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            
            _context.SaveChanges();
            return true;
        }

        public bool UpdateUser(int id, string name, string email)
        {
            var user = _context.Users.Find(id);
            if (user == null) return false;

            user.Name = name.Length > 5 ? name : user.Name;
            user.Email = email.Length > 5 ? email : user.Email;
            _context.SaveChanges();
            
            return true;
        }
        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList<Post>();
        }
        public Post? GetPost(int id)
        {
            return _context.Posts.Find(id);
        }

        public Post? AddPost(string content, int userId)
        {
            try
            {
                var post = _context.Posts.Add(new Post()
                {
                    Content = content,
                    UserId = userId
                });
                _context.SaveChanges();
                return post.Entity;
            }
            catch
            {
                  return null;
            }
        }

        public bool DeletePost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null) return false;
            _context.Posts.Remove(post);

            _context.SaveChanges();
            return true;
        }

        public bool UpdatePost(int id, string content)
        {
            var post = _context.Posts.Find(id);
            if (post == null) return false;

            post.Content = content;
            _context.SaveChanges();

            return true;
        }


    }
}

