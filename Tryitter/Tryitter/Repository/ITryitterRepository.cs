using System;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tryitter.Models;

namespace Tryitter.Repository
{
    public interface ITryitterRepository
    {
        IEnumerable<User> GetUsers();
        User? GetUser(int id);
        void AddUser(User user);
        bool DeleteUser(int id);
        bool UpdateUser(int id, string name, string email);
        Post? GetPost(int id);
        Post AddPost(string content, int userId);
        bool DeletePost(int id);
        bool UpdatePost(int id, string content);
        User Login(string email, string password);
        string GetOwnerPost(int id);
        IEnumerable<Post> GetPosts();
    }
}

