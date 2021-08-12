using System.Collections.Generic;
using CardGameSite.WEB.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CardGameSite.BLL.Infrastructure;
using CardGameSite.BLL.DTO;
using AutoMapper;
using System.Threading.Tasks;

namespace CardGameSite.WEB.Components
{
    public class ProductsEditorViewComponent : ViewComponent
    {
        private DataManagerServices _dataManager;
        private IMapper _mapper;

        public ProductsEditorViewComponent(DataManagerServices dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_dataManager.ProductService.GetObjectsDtoAsync().Result
                   .Select(p => _mapper.Map<ProductDTO, Product>(p)));
        }

        [HttpPost]
        public async Task<IViewComponentResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                Task task = Task.Factory.StartNew(()=>_dataManager.ProductService.SaveObjectAsync(_mapper.Map<Product, ProductDTO>(product)));
                await task;
                TempData["message"] = $"Товар Name = '{product.Name}' сохранен.";
                return View();
            }
            else
            {
                //Что-то не так со значениями данных 
                return View(product);
            }
        }
    }
}
