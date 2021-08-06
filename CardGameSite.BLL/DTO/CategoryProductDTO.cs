using System.Collections.Generic;


namespace CardGameSite.BLL.DTO
{
    public class CategoryProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
