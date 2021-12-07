using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Application
{
    public class UserRecord: IdentityUser
    {
        public virtual List<BoardRecord> Boards { get; set; } = new List<BoardRecord>();
    }
}