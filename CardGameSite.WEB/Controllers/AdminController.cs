using Microsoft.AspNetCore.Mvc;
using CardGameSite.WEB.Models;
using CardGameSite.BLL.Services.Interfaces;
using CardGameSite.BLL.DTO;
using AutoMapper;
using System.Linq;


namespace CardGameSite.WEB.Controllers
{
    public class AdminController : Controller
    {
        private IService<ProductDTO> _productService;
        private IMapper _mapper;
        public AdminController(IService<ProductDTO> service, IMapper mapper) {
            _productService = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_productService.GetObjectsDto()
                   .Select(p => _mapper.Map<ProductDTO, Product>(p)));
        }

        public ViewResult Edit(int productid)
        {
            return View(_productService.GetObjectsDto()
                   .Select(p => _mapper.Map<ProductDTO, Product>(p))
                   .FirstOrDefault(p => p.ProductId == productid));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.SaveObject(_mapper.Map<Product, ProductDTO>(product));
                TempData["message"] = $"Товар Name = '{product.Name}' сохранен.";
                return RedirectToAction("Index");
            }
            else
            {
                //Что-то не так со значениями данных 
                return View(product);
            }
        }

        [HttpPost]
        public IActionResult Delete(int productid)
        {
            Product deletedProduct = _mapper.Map < ProductDTO, Product>(_productService.DeleteObject(productid));
            if (deletedProduct != null)
            {
                TempData["message"] = $"Продукт Name = '{deletedProduct.Name}' удален.";                
            }
            return RedirectToAction("Index");
        }

        public ViewResult Create() => View("Edit", new Product());
    }
}
