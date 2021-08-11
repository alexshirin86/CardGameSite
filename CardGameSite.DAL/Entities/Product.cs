using CardGameSite.DAL.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardGameSite.DAL.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]        
        public string Name { get; set; }
                
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(4, 2)")]
        public decimal Price { get; set; }

        public List<CategoryProduct> CategoriesProduct { get; set; } = new List<CategoryProduct>();
    }
}
