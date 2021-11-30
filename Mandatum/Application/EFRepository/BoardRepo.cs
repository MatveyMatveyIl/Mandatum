using System;
using System.Linq;
using Infrastructure;
using Mandatum.Models;

namespace Application
{
    public class BoardRepo: IBoardRepo
    {
        //private readonly AbstractRepo abstractRepo;
        private readonly AppDbContext db;

        public BoardRepo(AppDbContext db)
        {
            this.db = db;
            //this.abstractRepo = abstractRepo;
        }

        public UserRecord GetData()
        {
            return db.Users.ToList().First();
            throw new NotImplementedException();
            /*using ()
            {
                
            }
            return data;*/
        }

        public void SaveData(int idBoard, BoardRecord record)
        {
            //abstractRepo.SaveData<BoardRecord>(idBoard, record);
        }
    }
}