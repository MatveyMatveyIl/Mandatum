using System;
using System.Collections.Generic;

namespace Application
{
    public class BoardRecord
    {
        public Guid Id { get; set; }
        public virtual List<TaskRecord> TaskIds { get; set; }
        public virtual List<UserRecord> UserIds { get; set; }
    }
}