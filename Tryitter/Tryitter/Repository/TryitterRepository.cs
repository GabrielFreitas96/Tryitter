﻿using System;
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
        public EntityEntry<User>? AddUser(User user)
        {
            var userExists = _context.Users.FirstOrDefault(x => x.email == user.email) == null;
            if (userExists) return null;
            
            var newUser = _context.Users.Add(user);
            _context.SaveChanges();
            return newUser;
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
            user.email = email.Length > 5 ? email : user.email;
            _context.SaveChanges();
            
            return true;
        }
        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.ToList<Post>();
        }
    }
}

