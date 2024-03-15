﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCampRestora.Domain.Entities.Authentication.Login
{
    public class LoginModel
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
