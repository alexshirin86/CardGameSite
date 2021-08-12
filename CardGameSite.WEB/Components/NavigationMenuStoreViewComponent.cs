using System.Collections.Generic;
using CardGameSite.WEB.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CardGameSite.BLL.Infrastructure;
using AutoMapper;

namespace CardGameSite.WEB.Components
{
    public class NavigationMenuStoreViewComponent : ViewComponent
    {
        private DataManagerServices _dataManager;
        private IMapper _mapper;

        public NavigationMenuStoreViewComponent(DataManagerServices dataManager, IMapper mapper)
        {
            _dataManager = dataManager;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            List<CategoryProduct> listCategoriesProduct = _dataManager.CategoriesProductService.GetObjectsDtoAsync().Result.Select(p => _mapper.Map<CategoryProduct>(p)).ToList();
            List<string> categoriesProduct = listCategoriesProduct.Select(g => g.Name).Distinct().ToList(); ;
                        
            return View(categoriesProduct);
        }
    }
}
