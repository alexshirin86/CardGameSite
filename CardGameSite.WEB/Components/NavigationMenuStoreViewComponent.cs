using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CardGameSite.BLL.Interfaces;

namespace CardGameSite.WEB.Components
{
    public class NavigationMenuStoreViewComponent : ViewComponent
    {
        private IProductService _service;
        public NavigationMenuStoreViewComponent(IProductService service)
        {
            _service = service;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View( _service.GetProducts()
                .Select(x => x.Categories)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
