using CardGameSite.DAL.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CardGameSite.DAL.Entities
{
    public class CategoryProduct : IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
