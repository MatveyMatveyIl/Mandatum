using System.Linq;
using Mandatum.Models;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class UserRepo: IUserRepo
    {
        private readonly AppDbContext dbContext;

        public UserRepo(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public UserRecord GetUser(UserRecord user)
        {   
            return dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
        }

        public void SaveUser(UserRecord user)
        {
            dbContext.Add(user);
            dbContext.SaveChanges();
        }
    }
}