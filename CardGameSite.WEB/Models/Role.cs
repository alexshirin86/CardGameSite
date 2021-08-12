using System.Collections.Generic;


namespace CardGameSite.WEB.Models
{
    public class Role
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public List<string> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public Role()
        {
            AllRoles = new List<string>();
            UserRoles = new List<string>();
        }
    }
}
