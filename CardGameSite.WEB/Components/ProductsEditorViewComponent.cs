using System.Collections.Generic;
using CardGameSite.WEB.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CardGameSite.BLL.Infrastructure;
using CardGameSite.BLL.DTO;
using AutoMapper;

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
            return View(_dataManager.ProductService.GetObjectsDto()
                   .Select(p => _mapper.Map<ProductDTO, Product>(p)));
        }
    }
}
