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
            var boardRecord = _dbContext.Boards.AsNoTracking().Include(prop => prop.TaskIds)
                .FirstOrDefault(board => board.Id == boardId);
            if (boardRecord is null) return new BoardRecord();
            return boardRecord;
        }

        public void UpdateBoard(BoardRecord updBoard)
        {
            var containsBoard = GetBoard(updBoard.Id);
            if (containsBoard is null) return;
            _dbContext.Boards.Update(updBoard);
            _dbContext.SaveChanges();
        }

        public void DeleteBoard(BoardRecord board)
        {
            var containsBoard = GetBoard(board.Id);
            if (containsBoard is null) return;
            _dbContext.Boards.Remove(board);
            _dbContext.SaveChanges();
        }
    }
}