using System.ComponentModel.DataAnnotations.Schema;


namespace CardGameSite.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public int Category { get; set; }
    }
}
