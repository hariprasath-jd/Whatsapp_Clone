using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Whatsapp_clone.Models.User
{
    public class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public UserDetails details { get; set; }
    }
}