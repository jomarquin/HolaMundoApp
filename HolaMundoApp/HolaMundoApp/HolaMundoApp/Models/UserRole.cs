﻿using HolaMundoApp.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolaMundoApp.Models
{
    public class UserRole
    {
        public long RoleId { get; set; }
        public string Name { get; set; }
        public RoleType Type { get; set; }

    }
}
