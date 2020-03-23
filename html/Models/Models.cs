using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace html.Models
{
    public class LoginModel
    {
        public string EmailOrLogin { get; set; }
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
      
    }
}