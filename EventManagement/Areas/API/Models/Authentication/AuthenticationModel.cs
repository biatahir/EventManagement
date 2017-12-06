using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventManagement.Areas.API.Models.Authentication
{
    public class AuthenticationModel : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }

        public AuthenticationModel()
        {
            Email = string.Empty;
            Password = string.Empty;
            Code = string.Empty;
        }
    }
}