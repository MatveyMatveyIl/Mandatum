using System.Collections.Generic;

namespace Application.ApiInterface
{
    public interface IUserApi
    {
        public void AddBoard(BoardRecord board, string email);
        public IEnumerable<BoardRecord> GetBoards(string email);
        public void AddNewUserToBoard(string email);
        public UserRecord GetUser(string email);
    }
}