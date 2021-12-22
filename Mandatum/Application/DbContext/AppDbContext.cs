using Application.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Application.DbContext
{
    public class AppDbContext: IdentityDbContext
    {
        public DbSet<UserRecord> Users { get; set; }
        public DbSet<BoardRecord> Boards { get; set; }
        public DbSet<TaskRecord> Tasks { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}