using Domain;

namespace Application
{
    public class BoardApi
    {
        public void CreateTask(TaskRecord task, int id)
        {
            var boardRecord = boardRepo.Get(id);
            var board = BoardRecordConvertToDomainBoard(boardRecord);
            board.AddTask(task);
            boardRepo.Save(BoardConvertToBoardRecord(board));
        }

        private BoardRecord BoardConvertToBoardRecord(Board board)
        {
            throw new System.NotImplementedException();
        }

        private Board BoardRecordConvertToDomainBoard(BoardRecord boardRecord)
        {
            throw new System.NotImplementedException();
        }
    }
}