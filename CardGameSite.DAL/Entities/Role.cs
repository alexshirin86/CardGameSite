using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using CardGameSite.DAL.Entities.Interfaces;

namespace CardGameSite.DAL.Entities
{
    public class Role : IdentityRole<int>, IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Required]
        [MaxLength(50)]
        public override string Name { get; set; }

    }
}
