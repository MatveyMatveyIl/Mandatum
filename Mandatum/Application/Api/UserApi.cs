namespace Application
{
    public class UserApi
    {
        private readonly UserRepo _userRepo;

        public UserApi(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public UserRecord CheckUser(UserRecord user)
        {
            return _userRepo.GetUser(user);
        }

        public void RegisterUser(UserRecord user)
        {
            _userRepo.SaveUser(user);
        }
    }
}