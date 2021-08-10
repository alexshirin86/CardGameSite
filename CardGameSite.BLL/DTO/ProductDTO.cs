using System.Collections.Generic;
using CardGameSite.BLL.DTO.Interfaces;


namespace CardGameSite.BLL.DTO
{
    public class ProductDTO : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<CategoryProductDTO> CategoriesProduct { get; set; }
    }
}
