/*using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Mandatum.Models
{
    public class UserRepo
    {
        //класс-репозиторий напрямую обращается к контексту базы данных
            private readonly UserContext _context;
            public UserRepo(UserContext context)
            {
                this._context = context;
            }
            
            public IQueryable<User> GetArticles()
            {
                return _context.Users.OrderBy(x => x.Email);
            }

            //найти определенную запись по id
            public User GetArticleById(Guid id)
            {
                return _context.Users.Single(x => x.Id == id);
            }

            //сохранить новую либо обновить существующую запись в БД
            public Guid SaveArticle(User entity)
            {
                if (entity.Id == default)
                    _context.Entry(entity).State = EntityState.Added;
                else
                    _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

                return entity.Id;
            }
    }
    
}*/