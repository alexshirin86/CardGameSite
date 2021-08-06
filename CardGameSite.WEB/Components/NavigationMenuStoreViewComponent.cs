using System.Collections.Generic;
using CardGameSite.WEB.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CardGameSite.BLL.Services.Interfaces;
using CardGameSite.BLL.DTO;
using AutoMapper;

namespace CardGameSite.WEB.Components
{
    public class NavigationMenuStoreViewComponent : ViewComponent
    {
        private IService<CategoryProductDTO> _service;
        private IMapper _mapper;

        public NavigationMenuStoreViewComponent(IService<CategoryProductDTO> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            List<CategoryProduct> listCategoriesProduct = _service.GetObjectsDto().Select(p => _mapper.Map<CategoryProductDTO, CategoryProduct>(p)).ToList();
            List<string> categoriesProduct = listCategoriesProduct.Select(g => g.Name).Distinct().ToList(); ;
                        
            return View(categoriesProduct);
        }
    }
}
