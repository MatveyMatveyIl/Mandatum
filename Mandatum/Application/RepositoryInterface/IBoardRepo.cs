using System;
using Application.Entities;

namespace Application.RepositoryInterface
{
    public interface IBoardRepo
    {
        public void SaveBoard(BoardRecord board);
        public BoardRecord GetBoard(Guid boardId);
        public void UpdateBoard(BoardRecord updBoard);
        public void DeleteBoard(BoardRecord board);
    }
}