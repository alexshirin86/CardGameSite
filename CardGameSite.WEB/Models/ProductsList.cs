using System.Collections.Generic;
using CardGameSite.BLL.DTO;


namespace CardGameSite.WEB.Models
{
    public class ProductsList
    {
        public IEnumerable<Product> Products { get; set; }
        public ProductsListPagingInfo PagingInfo { get; set; }

        public int CurrentCategory { get; set; }
    }
}
