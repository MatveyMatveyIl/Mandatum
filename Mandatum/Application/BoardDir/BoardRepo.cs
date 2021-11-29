using Infrastructure;

namespace Application
{
    public class BoardRepo: IBoardRepo
    {
        private readonly AbstractRepo<BoardRecord> abstractRepo;

        public BoardRepo(AbstractRepo<BoardRecord> abstractRepo)
        {
            this.abstractRepo = abstractRepo;
        }

        public BoardRecord GetData(int idBoard)
        {
            var data = abstractRepo.GetData<BoardRecord>(idBoard);
            return data;
        }

        public void SaveData(int idBoard, BoardRecord record)
        {
            abstractRepo.SaveData<BoardRecord>(idBoard, record);
        }
    }
}