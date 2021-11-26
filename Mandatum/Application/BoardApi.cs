using Domain;

namespace Application
{
    public class BoardApi
    {
        public void CreateTask(TaskRecord task, int idBoard)
        {
            var boardRecord = boardRepo.Get(idBoard);
            var board = BoardRecordConvertToDomainBoard(boardRecord);
            board.AddTask(TaskRecordConvertToDomainTask(task));
            boardRepo.Save(BoardConvertToBoardRecord(board));
        }

        private Task TaskRecordConvertToDomainTask(TaskRecord task)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTask(TaskRecord task, int id)
        {
            
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