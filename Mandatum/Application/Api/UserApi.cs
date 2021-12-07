using System;

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

        public void AddBoard(BoardRecord board, string email)
        {
            var user = _userRepo.GetUser(email);
            if (user is null)
                Console.WriteLine("user is null");
            user.Boards.Add(board);
            _userRepo.UpdateUser(user);
        }
    }
}