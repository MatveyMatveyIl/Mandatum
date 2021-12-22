using System.Collections.Generic;
using Application.Entities;

namespace Application.ApiInterface
{
    public interface IUserApi
    {
        public void AddBoard(BoardRecord board, string email);
        public IEnumerable<BoardRecord> GetBoards(string email);
        public UserRecord GetUser(string email);
    }
}