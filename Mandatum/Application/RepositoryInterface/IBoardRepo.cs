namespace Application
{
    public interface IBoardRepo
    {
        public UserRecord GetData();
        public void SaveData(int idBoard, BoardRecord record);
    }
}