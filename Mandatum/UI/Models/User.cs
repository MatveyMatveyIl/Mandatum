﻿using System;

namespace Mandatum.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
    }
}