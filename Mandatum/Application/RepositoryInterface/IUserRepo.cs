namespace Application
{
    public interface IUserRepo
    {
        public void UpdateUser(UserRecord user);
        public UserRecord GetUser(string email);
    }
}