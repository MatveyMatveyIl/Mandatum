using System;
using System.Collections.Generic;

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
            user.Boards.Add(board);
            _userRepo.UpdateUser(user);
        }

        public IEnumerable<BoardRecord> GetBoards(string email)
        {
            var user = _userRepo.GetUser(email);
            return user.Boards;
        }
    }
}