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
            try
            {
                return _dbContext.Users.Include(x => x.Boards).FirstOrDefault(u => u.Email == email);
            }
            catch
            {
                return new UserRecord();
            }
        }

        public void UpdateUser(UserRecord user)
        {
            try
            {
                _dbContext.Update(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                //
            }
        }
    }
}