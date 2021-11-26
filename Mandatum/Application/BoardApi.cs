using Domain;

namespace Application
{
    public class BoardApi
    {
        private readonly BoardRepo boardRepo;

        public BoardApi(BoardRepo boardRepo)
        {
            this.boardRepo = boardRepo;
        }

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
            throw new System.NotImplementedException();
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