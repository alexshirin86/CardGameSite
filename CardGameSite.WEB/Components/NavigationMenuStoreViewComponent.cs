using System.Collections.Generic;
using CardGameSite.WEB.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CardGameSite.BLL.Interfaces;
using CardGameSite.BLL.DTO;
using AutoMapper;

namespace CardGameSite.WEB.Components
{
    public class NavigationMenuStoreViewComponent : ViewComponent
    {
        private IProductService _service;
        private IMapper _mapper;

        public NavigationMenuStoreViewComponent(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            List<List<CategoryProduct>> listCategoriesProduct = _service.GetProducts().Select(p => _mapper.Map<ProductDTO, Product>(p))
                .Select(x => x.Categories).ToList();
            List<string> categoriesProduct = listCategoriesProduct.SelectMany(v => v).Select(g => g.Name).Distinct().ToList();
            return View(categoriesProduct);
        }
    }
}
