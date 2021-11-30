using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AbstractRepo
    {
        private readonly IRepoConfig config;

        public AbstractRepo(IRepoConfig config)
        {
            this.config = config;
        }

        public T GetData<T>(Func<DbContext, T> f)
        {
            throw new NotImplementedException();
            /*using (var db = AppDbContext())
            {
                
            }*/
        }

        public void SaveData<T>(int id, T record)
        {
            throw new NotImplementedException();
        }
    }
}