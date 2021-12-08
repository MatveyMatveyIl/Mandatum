using System;
using System.Linq;
using Mandatum.Models;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    public class BoardRepo : IBoardRepo
    {
        private readonly AppDbContext _dbContext;

        public BoardRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void SaveBoard(BoardRecord board)
        {
            _dbContext.Boards.Add(board);
            _dbContext.SaveChanges();
        }

        public BoardRecord GetBoard(Guid boardId)
        {
            return _dbContext.Boards.Include(x => x.TaskIds).FirstOrDefault(u => u.Id == boardId);
        }

        public void UpdateBoard(BoardRecord board)
        {
            _dbContext.Update(board);
            _dbContext.SaveChanges();
        }
    }
}