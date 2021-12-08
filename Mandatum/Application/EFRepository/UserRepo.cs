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

        public UserRecord GetUser(UserRecord user)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Email == user.Email);
        }

        public UserRecord GetUser(string email)
        {
            return _dbContext.Users.Include(x => x.Boards).FirstOrDefault(u => u.Email == email);
        }

        public UserRecord GetUser(Guid userid)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == userid.ToString());
        }

        public void SaveUser(UserRecord user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(UserRecord user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }
    }
}