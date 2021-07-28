using CardGameSite.BLL.DTO;
using System.Collections.Generic;


namespace CardGameSite.BLL.Interfaces
{
    public interface IProductService
    {
        ProductDTO GetProduct(int? id);
        IEnumerable<ProductDTO> GetProducts();
        void Dispose();
    }
}
