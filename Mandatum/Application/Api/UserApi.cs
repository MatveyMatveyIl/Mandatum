using System.Collections.Generic;
using Application.ApiInterface;
using Application.Entities;
using Application.RepositoryInterface;

namespace Application.Api
{
    public class UserApi : IUserApi
    {
        private readonly IUserRepo _userRepo;

        public UserApi(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public UserRecord GetUser(string email)
        {
            return _userRepo.GetUser(email);
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