using System;
using System.Collections.Generic;

namespace Application
{
    public class BoardRecord
    {
        public Guid Id { get; set; }
        public List<int> TaskIds { get; set; }
        public List<int> UserIds { get; set; }
    }
}