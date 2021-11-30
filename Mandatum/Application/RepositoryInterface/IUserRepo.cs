namespace Application
{
    public interface IUserRepo
    {
        public UserRecord GetUser(UserRecord user);
        public void SaveUser(UserRecord user);
    }
}