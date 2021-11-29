/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;

namespace Mandatum.Models
{
    public sealed class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
           public UserContext(DbContextOptions<UserContext> options)
               : base(options)
           {
               Database.EnsureCreated();
           }
    }
}*/