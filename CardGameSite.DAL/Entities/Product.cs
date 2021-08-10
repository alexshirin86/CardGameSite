using CardGameSite.DAL.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CardGameSite.DAL.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public List<CategoryProduct> CategoriesProduct { get; set; } = new List<CategoryProduct>();
    }
}
