using Microsoft.AspNetCore.Identity;
using CardGameSite.DAL.Entities.Interfaces;

namespace CardGameSite.DAL.Entities
{
    public class User : IdentityUser<int>, IEntity
    {        
        public string Name { get; set; }

        public User() { }
    }
}
