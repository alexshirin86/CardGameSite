using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace CardGameSite.WEB.Models
{
    public class User : IdentityUser<int>
    {
        //public int UserId { get; set; }

        //public string UserName { get; set; }

        //public string Email { get; set; }
        public User() {}

    }
}
