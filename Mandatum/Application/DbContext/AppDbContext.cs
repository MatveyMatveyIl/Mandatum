using System;
using System.Collections.Generic;
using Application;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mandatum.Models
{
    public class AppDbContext: IdentityDbContext
    {
        public DbSet<UserRecord> Users { get; set; }
        public DbSet<BoardRecord> Boards { get; set; }
        public DbSet<TaskRecord> Tasks { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}