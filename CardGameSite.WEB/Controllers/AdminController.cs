using Microsoft.AspNetCore.Mvc;
using CardGameSite.WEB.Models;
using CardGameSite.BLL.Infrastructure;
using CardGameSite.BLL.DTO;
using AutoMapper;
using System.Linq;


namespace CardGameSite.WEB.Controllers
{
    public class AdminController : Controller
    {
        private DataManagerServices _dataManager;
        private IMapper _mapper;

        public AdminController(DataManagerServices dataManager, IMapper mapper) {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Edit(int productid)
        {
            return View(_dataManager.ProductService.GetObjectsDtoAsync().Result
                   .Select(p => _mapper.Map<ProductDTO, Product>(p))
                   .FirstOrDefault(p => p.ProductId == productid));
        }

        

        [HttpPost]
        public IActionResult Delete(int productid)
        {
            Product deletedProduct = _mapper.Map < ProductDTO, Product>(_dataManager.ProductService.DeleteObjectAsync(productid).Result);
            if (deletedProduct != null)
            {
                TempData["message"] = $"Продукт Name = '{deletedProduct.Name}' удален.";                
            }
            return RedirectToAction("Index");
        }

        public ViewResult Create() => View("Edit", new Product());
    }
}
