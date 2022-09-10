﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Silas.Authentication.Models.Auth
{
    public class TokenLinkConfigurationModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }

        public string Scope { get; set; }

        public string RefreshToken { get; set; }
        public string Created { get; set; }

    }
}
