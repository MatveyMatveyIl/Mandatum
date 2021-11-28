using System.Collections.Generic;

namespace Application
{
    public class BoardRecord
    {
        public int Id { get;  set; }
        public List<int> TaskIds { get; } = new List<int>();
        public List<int> UserIds { get; } = new List<int>();
    }
}