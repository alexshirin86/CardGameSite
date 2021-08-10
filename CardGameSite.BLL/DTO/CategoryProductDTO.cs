using System.Collections.Generic;
using CardGameSite.BLL.DTO.Interfaces;


namespace CardGameSite.BLL.DTO
{
    public class CategoryProductDTO : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
