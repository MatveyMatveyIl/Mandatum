namespace Application
{
    public interface IBoardRepo
    {
        public BoardRecord GetData(int idBoard);
        public void SaveData(int idBoard, BoardRecord record);
    }
}