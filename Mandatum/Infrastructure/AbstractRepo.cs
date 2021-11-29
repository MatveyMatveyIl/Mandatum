using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Infrastructure
{
    public class AbstractRepo<T> where T:class
    {
        private readonly T _context;
        private readonly DbSet<T> field;
        private DbSet<T> table { get; set; }

        public AbstractRepo(T context)
        {
            _context = context;
        }

        public T GetData<T>(int id)
        {
            table.FirstOrDefaultAsync(u => u)
            throw new NotImplementedException();
        }

        public void SaveData<T>(int id, T record)
        {
            throw new NotImplementedException();
        }
    }
}