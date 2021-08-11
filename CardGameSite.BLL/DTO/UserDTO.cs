using Microsoft.AspNetCore.Identity;
using CardGameSite.BLL.DTO.Interfaces;

namespace CardGameSite.BLL.DTO
{
    public class UserDTO : IdentityUser<int>, IDto
    {
        public override int Id { get; set; }
    }
}
