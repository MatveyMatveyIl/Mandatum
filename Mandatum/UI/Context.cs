using System;
using System.Collections.Generic;
using Application;
using Microsoft.EntityFrameworkCore;

namespace Mandatum
{
    public class Context: DbContext
    {
        public DbSet<UserRecord> Users { get; set; }
        public DbSet<BoardRecord> Boards { get; set; }
        public DbSet<TaskRecord> Tasks { get; set; }
        
        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}