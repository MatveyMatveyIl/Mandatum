using System;
using System.Collections.Generic;

namespace Application
{
    public class BoardRecord
    {
        public Guid Id { get; set; }
        public List<Guid> TaskIds { get; set; }
        public List<Guid> UserIds { get; set; }
    }
}