using CardGameSite.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using CardGameSite.BLL.Interfaces;


namespace CardGameSite.WEB.Controllers
{
    public class StoreController : Controller
    {
        public int PageSize = 4;

        private readonly ILogger<StoreController> _logger;

        private IProductService _productService;

        public StoreController(IProductService serv, ILogger<StoreController> logger)
        {
            _logger = logger;
            _productService = serv;
        }

        public ViewResult Store(int category, int productPage = 1)
           => View(new ProductsList
           {
               Products = _productService.GetProducts()
                   .Where(p => category == 0 || p.Category == category)
                   .OrderBy(p => p.Id)
                   .Skip((productPage - 1) * PageSize)
                   .Take(PageSize),
               PagingInfo = new ProductsListPagingInfo
               {
                   CurrentPage = productPage,
                   ItemsPerPage = PageSize,
                   TotalItems = category == 0 ?
                        _productService.GetProducts().Count() :
                        _productService.GetProducts().Where(e =>
                            e.Category == category).Count()
               },
               CurrentCategory = category
           });
    }
}
