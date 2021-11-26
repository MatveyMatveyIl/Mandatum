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
            throw new System.NotImplementedException();
        }

        public void SaveData(BoardRecord boardConvertToBoardRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}