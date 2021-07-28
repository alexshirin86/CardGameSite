using System.Collections.Generic;
using CardGameSite.BLL.DTO;


namespace CardGameSite.WEB.Models
{
    public class ProductsList
    {
        public IEnumerable<ProductDTO> Products { get; set; }
        public ProductsListPagingInfo PagingInfo { get; set; }

        public int CurrentCategory { get; set; }
    }
}
