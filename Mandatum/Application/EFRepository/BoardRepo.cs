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
            try
            {
                _dbContext.Boards.Add(board);
                _dbContext.SaveChanges();
            }
            catch
            {
                //
            }
        }

        public BoardRecord GetBoard(Guid boardId)
        {
            try
            {
                return _dbContext.Boards.AsNoTracking().Include(prop => prop.TaskIds).FirstOrDefault(board => board.Id == boardId);
            }
            catch
            {
                return new BoardRecord();
            }
        }

        public void UpdateBoard(BoardRecord updBoard)
        {
            try
            {
                _dbContext.Boards.Update(updBoard);
                _dbContext.SaveChanges();
            }
            catch
            {
                //
            }
        }

        public void DeleteBoard(BoardRecord board)
        {
            try
            {
                _dbContext.Boards.Remove(board);
                _dbContext.SaveChanges();
            }
            catch
            {
                //
            }
        }
    }
}