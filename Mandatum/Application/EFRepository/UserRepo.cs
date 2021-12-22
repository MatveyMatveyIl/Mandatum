using System;
using System.Linq;
using Mandatum.Models;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext _dbContext;

        public UserRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserRecord GetUser(string email)
        {
            return _dbContext.Users.Include(x => x.Boards).FirstOrDefault(u => u.Email == email);
        }

        public void UpdateUser(UserRecord user)
        {
            if (GetUser(user.Email) is null) return;
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }
    }
}