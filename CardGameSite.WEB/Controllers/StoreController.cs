using CardGameSite.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using CardGameSite.BLL.Services.Interfaces;
using CardGameSite.BLL.DTO;
using AutoMapper;


namespace CardGameSite.WEB.Controllers
{
    public class StoreController : Controller
    {
        public int PageSize = 4;

        private readonly ILogger<StoreController> _logger;
        private IMapper _mapper;

        private IService<ProductDTO> _productService;

        public StoreController(IService<ProductDTO> service, IMapper mapper, ILogger<StoreController> logger)
        {
            _logger = logger;
            _productService = service;
            _mapper = mapper;
        }

        public ViewResult Store(string category, int productPage = 1)
        {
            
            ProductsList productList = new ProductsList()
            {
                Products = _productService.GetObjectsDto()                   
                   .Select(p => _mapper.Map<ProductDTO, Product>(p))
                   .Where(p => category == null || p.CategoriesProduct.Where(c => c.Name == category).ToList<CategoryProduct>().Count > 0)
                   .OrderBy(p => p.ProductId)
                   .Skip((productPage - 1) * PageSize)
                   .Take(PageSize),

                PagingInfo = new ProductsListPagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        _productService.GetObjectsDto().Count() :
                        _productService.GetObjectsDto()
                            .Select(e => e.CategoriesProduct.Where(v => v.Name == category)).Count()
                },
                CurrentCategory = category
            };

            
            return View(productList);
        }
          
    }
}
