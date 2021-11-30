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

        public UserRecord GetData()
        {
            return db.Users.ToList().First();
        }

        public void SaveData(int idBoard, BoardRecord record)
        {
            //abstractRepo.SaveData<BoardRecord>(idBoard, record);
        }
    }
}