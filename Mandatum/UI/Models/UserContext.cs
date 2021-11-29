using System;
using System.Data;
using Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

namespace Mandatum.Models
{
    public sealed class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid("716C2E99-6F6C-4472-81A5-43C56E11637C"),
                Email = "1",
                Password = "text"
            });
        }
    }
}