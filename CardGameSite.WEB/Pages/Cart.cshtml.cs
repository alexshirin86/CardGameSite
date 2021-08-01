using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CardGameSite.WEB.Infrastructure;
using CardGameSite.WEB.Models;
using CardGameSite.BLL.Interfaces;
using CardGameSite.BLL.DTO;
using System.Linq;
using AutoMapper;

namespace CardGameSite.WEB.Pages
{
    public class CartModel : PageModel
    {
        private IProductService _service; 
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        private IMapper _mapper;

        public CartModel(IProductService service, Cart cartService, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            Cart = cartService;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product product = _service.GetProducts().Select(p => _mapper.Map<ProductDTO, Product>(p))
                .FirstOrDefault(p => p.ProductId == productId);
            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Product.ProductId == productId).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
