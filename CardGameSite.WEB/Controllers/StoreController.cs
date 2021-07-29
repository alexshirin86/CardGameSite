using CardGameSite.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using CardGameSite.BLL.Interfaces;
using CardGameSite.BLL.DTO;
using AutoMapper;


namespace CardGameSite.WEB.Controllers
{
    public class StoreController : Controller
    {
        public int PageSize = 4;

        private readonly ILogger<StoreController> _logger;
        private IMapper _mapper;

        private IProductService _productService;

        public StoreController(IProductService service, IMapper mapper, ILogger<StoreController> logger)
        {
            _logger = logger;
            _productService = service;
            _mapper = mapper;

    }

    public ViewResult Store(int category, int productPage = 1)
           => View(new ProductsList
           {
               Products = _productService.GetProducts().Select(p => _mapper.Map<ProductDTO, Product>(p))
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
