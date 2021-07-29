using System.Collections.Generic;


namespace CardGameSite.BLL.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<CategoryProductDTO> Categories { get; set; }
    }
}
