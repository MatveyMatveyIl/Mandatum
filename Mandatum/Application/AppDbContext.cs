using System;
using System.Collections.Generic;
using Application;
using Microsoft.EntityFrameworkCore;

namespace Mandatum.Models
{
    public class AppDbContext: DbContext
    {
        public DbSet<UserRecord> Users { get; set; }
        public DbSet<BoardRecord> Boards { get; set; }
        public DbSet<TaskRecord> Tasks { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}