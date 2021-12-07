using System;
using System.Linq;
using Infrastructure;
using Mandatum.Models;

namespace Application
{
    public class BoardRepo: IBoardRepo
    {
        private readonly AppDbContext db;

        public BoardRepo(AppDbContext db)
        {
            this.db = db;
        }
        

        public void SaveBoard(BoardRecord board)
        {
            db.Boards.Add(board);
            db.SaveChanges();
        }

        public BoardRecord GetBoard(Guid boardId)
        {
            return db.Boards.FirstOrDefault(u => u.Id == boardId);
        }

        public void UpdateBoard(BoardRecord board)
        {
            db.Update(board);
            db.SaveChanges();
        }
    }
}