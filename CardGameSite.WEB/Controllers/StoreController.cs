using CardGameSite.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using CardGameSite.BLL.Services;
using System.Linq;
using CardGameSite.BLL.DTO;
using AutoMapper;


namespace CardGameSite.WEB.Controllers
{
    public class StoreController : Controller
    {
        public int PageSize = 4;

        private IMapper _mapper;

        private DataManagerServices _dataManager;

        public StoreController(DataManagerServices dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public ViewResult Store(string category, int productPage = 1)
        {
            
            ProductsList productList = new ProductsList()
            {
                Products = _dataManager.ProductService.GetObjectsDtoAsync().Result                  
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
                        _dataManager.ProductService.GetObjectsDtoAsync().Result.Count() :
                        _dataManager.ProductService.GetObjectsDtoAsync().Result
                            .Select(e => e.CategoriesProduct.Where(v => v.Name == category)).Count()
                },

                CurrentCategory = category
            };

            
            return View(productList);
        }
          
    }
}
