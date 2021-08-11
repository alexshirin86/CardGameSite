using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameSite.BLL.DTO;
using CardGameSite.BLL.Services.Interfaces;

namespace CardGameSite.BLL.Infrastructure
{
    public class DataManagerServices
    {
        private IService<ProductDTO> _productService;
        private IService<CategoryProductDTO> _categoriesProductService;
        private IService<UserDTO> _userService;

        public DataManagerServices(IService<ProductDTO> productService,
                                   IService<CategoryProductDTO> categoriesProductService,
                                   IService<UserDTO> userService)
        {
            _productService = productService;
            _categoriesProductService = categoriesProductService;
            _userService = userService;

    }

    public IService<ProductDTO> ProductService { get { return _productService; } }
    public IService<CategoryProductDTO> CategoriesProductService { get { return _categoriesProductService; } }
    public IService<UserDTO> UserService { get { return _userService; } }

    }
}
