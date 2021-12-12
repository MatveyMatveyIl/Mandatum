using System.Collections.Generic;

namespace Mandatum.Models
{
    public class BoardViewModel
    {
        public BoardModel Board { get; }
        public IEnumerable<TaskModel> Tasks { get; }

        public BoardViewModel(BoardModel board, IEnumerable<TaskModel> tasks)
        {
            Board = board;
            Tasks = tasks;
        } 
    }
}