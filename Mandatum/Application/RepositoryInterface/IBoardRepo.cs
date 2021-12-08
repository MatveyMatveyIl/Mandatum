using System;

namespace Application
{
    public interface IBoardRepo
    {
        public void SaveBoard(BoardRecord board);
        public BoardRecord GetBoard(Guid boardId);
        public void UpdateBoard(BoardRecord updBoard);
    }
}