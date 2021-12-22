using System;
using System.Collections.Generic;

namespace Mandatum.Models
{
    public class BoardViewModel
    {
        public Guid Id { get; set; }
        public bool Privacy { get; set; }
        public string Name { get; set; }
        
        public string ViewName { get; set; }
   
        public IEnumerable<TaskModel> Tasks { get; }

        public BoardViewModel(BoardModel boardModel, IEnumerable<TaskModel> tasks)
        {
            Id = boardModel.Id;
            Privacy = boardModel.Privacy;
            ViewName = boardModel.Format.ToString();
            Name = boardModel.Name;
            Tasks = tasks;
        }
    }
}