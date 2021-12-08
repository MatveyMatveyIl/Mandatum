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
            return _dbContext.Boards.Include(prop => prop.TaskIds).FirstOrDefault(board => board.Id == boardId);
        }

        public void UpdateBoard(BoardRecord updBoard)
        {
            _dbContext.Update(updBoard);
            _dbContext.SaveChanges();
        }

        public void DeleteBoard(BoardRecord board)
        {
            _dbContext.Boards.Remove(board);
            _dbContext.SaveChanges();
        }
    }
}