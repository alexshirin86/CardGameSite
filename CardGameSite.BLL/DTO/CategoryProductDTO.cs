using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameSite.BLL.DTO
{
    public class CategoryProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
