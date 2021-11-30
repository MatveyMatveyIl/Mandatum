using System;
using Infrastructure;
using Mandatum.Models;

namespace Application
{
    public class BoardRepo: IBoardRepo
    {
        private readonly AbstractRepo abstractRepo;
        //private readonly AppDbContext db;

        public BoardRepo(AbstractRepo abstractRepo)
        {
            this.abstractRepo = abstractRepo;
        }

        public BoardRecord GetData(int idBoard)
        {
            throw new NotImplementedException();
            /*using ()
            {
                
            }
            return data;*/
        }

        public void SaveData(int idBoard, BoardRecord record)
        {
            abstractRepo.SaveData<BoardRecord>(idBoard, record);
        }
    }
}