using System.Collections.Generic;

namespace Application
{
    public class BoardRecord
    {
        public int Id { get; private set; }
        public List<int> TaskIds { get; private set; }
        public List<int> UserIds { get; private set; }
    }
}