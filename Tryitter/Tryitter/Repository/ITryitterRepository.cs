using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tryitter.Models;

namespace Tryitter.Repository
{
    public interface ITryitterRepository
    {
        IEnumerable<User> GetUsers();
        User? GetUser(int id);
        IEnumerable<Post> GetPosts();
        EntityEntry<User> AddUser(User user);
        public bool DeleteUser(int id);
        public bool UpdateUser(int id, string name, string email);
    }
}

