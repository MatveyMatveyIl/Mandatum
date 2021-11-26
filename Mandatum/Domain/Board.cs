using System;

namespace Domain
{
    public class Board: Entity<int>
    {
        public int Id { get; private set; }
        
        public Board(int id) : base(id)
        {
            Id = id;
        }

        public void AddTask(Task task)
        {
            
        }
    }
}