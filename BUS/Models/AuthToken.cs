﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BUS.Models
{
    public class AuthToken
    {
        public string Token { get; set; }
        public DateTime Exprire { get; set; }
        public string RefreshToken { get; set; }
    }
}
