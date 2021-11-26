using System.Linq;
using Domain;

namespace Application
{
    public class BoardApi
    {
        private BoardRepo boardRepo;

        public BoardApi(BoardRepo boardRepo)
        {
            this.boardRepo = boardRepo;
        }

        public void CreateTask(string idBoard)
        {
            var boardRecords = boardRepo.Start();
            var boardRecord = boardRecords.First(board => board.Id == idBoard);
            var board = BoardRecordConvertToDomainBoard(boardRecord);
            //board.AddTask(TaskRecordConvertToDomainTask(task));
            //boardRepo.Save(BoardConvertToBoardRecord(board));
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