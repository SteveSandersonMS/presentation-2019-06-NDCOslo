using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MissionControl.Shared
{
    public class LoginCredentials
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool AcceptTerms { get; set; }
    }
}
