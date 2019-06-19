using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MissionControl.Shared
{
    public class LoginCredentials
    {
        [Required, MaxLength(10)]
        public string UserName { get; set; }

        [Required, MinLength(2), MaxLength(30)]
        public string Password { get; set; }

        [Required, Range(typeof(bool), "true", "true", ErrorMessage = "You must accept terms")]
        public bool AcceptTerms { get; set; }
    }
}
