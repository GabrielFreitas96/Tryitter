using System;
using Microsoft.EntityFrameworkCore;
using Tryitter.Models;
namespace Tryitter.Repository
{
    public interface IContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public int SaveChanges();
    }
}

