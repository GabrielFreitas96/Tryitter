﻿using System;
using Microsoft.EntityFrameworkCore;
using Tryitter.Models;

namespace Tryitter.Repository
{
    public class TryitterRepository : DbContext, IRepository 
    {
      public TryitterRepository(DbContextOptions<IRepository> options): base(options) { }
      public TryitterRepository() { }
      public DbSet<User> Users { get; set; }
      public DbSet<Post> Posts { get; set; }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=VideoPortal;User=SA;Password=Password12!;");
            }
        }
    }
}
