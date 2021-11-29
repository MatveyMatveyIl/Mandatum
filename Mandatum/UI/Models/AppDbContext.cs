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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserRecord>().HasData(new UserRecord()
            {
                Id = new Guid("62486D13-C455-43F8-8EA6-C1B44C0804A8"),
                Email = "1@gmail.com",
                Password = "1",
            });
            modelBuilder.Entity<BoardRecord>().HasData(new BoardRecord()
            {
                Id = new Guid("96CC1E82B59F43CFAB61244585F2C662"),
                TaskIds = new List<TaskRecord>(),
                UserIds = new List<UserRecord>(),
            });
            modelBuilder.Entity<TaskRecord>().HasData(new TaskRecord()
            {
                Id = new Guid("578181d8-e7bf-4a38-8cde-c9671e5efe58"),
                Description = "1",
                Status = TaskStatusRecord.Done,
                Topic = "1",
                Term = DateTime.Now,
            });
        }
    }
}