namespace Application
{
    public class DataManager
    {
        public IUserRepo User { get; set; }

        public DataManager(IUserRepo user)
        {
            User = user;
        }
    }
}