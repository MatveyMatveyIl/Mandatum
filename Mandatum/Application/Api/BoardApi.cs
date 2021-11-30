using System;
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

        public void Fuck()
        {
            Console.WriteLine(boardRepo.GetData().Email);
        }

        /*public void CreateTask(TaskRecord task, int idBoard)
        {
            var boardRecord = boardRepo.GetData(idBoard);
            var board = BoardRecordConvertToDomainBoard(boardRecord);
            board.AddTask(TaskRecordConvertToDomainTask(task));
            boardRepo.SaveData(idBoard, BoardConvertToBoardRecord(board));
        }

        private Task TaskRecordConvertToDomainTask(TaskRecord task)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTask(TaskRecord task, int idBoard, int idTask)
        {
            var boardRecord = boardRepo.GetData(idBoard);
            var board = BoardRecordConvertToDomainBoard(boardRecord);
            board.UpdateTask(TaskRecordConvertToDomainTask(task), idTask);
            boardRepo.SaveData(idBoard, BoardConvertToBoardRecord(board));
        }

        private BoardRecord BoardConvertToBoardRecord(Board board)
        {
            throw new System.NotImplementedException();
        }

        private Board BoardRecordConvertToDomainBoard(BoardRecord boardRecord)
        {
            throw new System.NotImplementedException();
        }*/
    }
}