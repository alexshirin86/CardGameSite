using Microsoft.AspNetCore.Mvc;
using CardGameSite.WEB.Models;
using CardGameSite.BLL.Infrastructure;
using CardGameSite.BLL.DTO;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;


namespace CardGameSite.WEB.Controllers
{
    public class ProductsManagerController : Controller
    {
        private DataManagerServices _dataManager;
        private IMapper _mapper;
                
        public ProductsManagerController(DataManagerServices dataManager, IMapper mapper) {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            return View(_dataManager.ProductService.GetObjectsDtoAsync().Result
                   .Select(p => _mapper.Map<ProductDTO, Product>(p)));
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int productid)
        {
            var products = await _dataManager.ProductService.GetObjectsDtoAsync();
            return View(products
                   .Select(p => _mapper.Map<ProductDTO, Product>(p))
                   .FirstOrDefault(p => p.ProductId == productid));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                //Task task = Task.Factory.StartNew(()=> _dataManager.ProductService.SaveObjectAsync(_mapper.Map<Product, ProductDTO>(product)));
                await _dataManager.ProductService.SaveObjectAsync(_mapper.Map<Product, ProductDTO>(product));
                //await task;
                TempData["message"] = $"Товар Name = '{product.Name}' сохранен.";
                return RedirectToAction("Index");
            }
            else
            {
                //Что-то не так со значениями данных 
                return View(product);
            }
        }


        [Authorize(Roles = "admin")]
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

        [Authorize(Roles = "admin")]
        public ViewResult Create() => View("Edit", new Product());
    }
}
