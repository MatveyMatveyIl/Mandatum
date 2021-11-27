using Infrastructure;

namespace Application
{
    public class BoardRepo
    {
        private readonly AbstractRepo abstractRepo;

        public BoardRepo(AbstractRepo abstractRepo)
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