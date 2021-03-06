using Microsoft.AspNetCore.Identity;
using CardGameSite.DAL.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardGameSite.DAL.Entities
{
    public class User : IdentityUser<int>, IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Required]
        [MaxLength(50)]
        public override string UserName { get; set; }

        public User() { }
    }
}
