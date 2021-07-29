using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CardGameSite.WEB.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public List<CategoryProduct> Categories { get; set; }
    }
}
