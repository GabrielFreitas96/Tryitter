using System;
using Tryitter.Models;

namespace Tryitter.Repository
{
    public interface ITryitterRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<Post> GetPosts();
        void AddUser(User user);
    }
}

