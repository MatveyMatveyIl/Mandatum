using Application.Entities;

namespace Application.RepositoryInterface
{
    public interface IUserRepo
    {
        public void UpdateUser(UserRecord user);
        public UserRecord GetUser(string email);
    }
}