using System;
using System.Collections.Generic;

namespace Domain
{
    public class User: Entity<int>
    {
        public int Id { get; private set; }
        public List<Board> Boards { get; set; }
        
        public User(int id): base(id)
        {
            Id = id;
        }
    }
}