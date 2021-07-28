using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CardGameSite.WEB.Infrastructure;
using CardGameSite.WEB.Models;
using CardGameSite.BLL.Interfaces;
using CardGameSite.BLL.DTO;
using System.Linq;

namespace CardGameSite.WEB.Pages
{
    public class CartModel : PageModel
    {
        private IProductService _service; 
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel(IProductService service)
        {
            _service = service;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int productId, string returnUrl)
        {
            ProductDTO product = _service.GetProducts()
                .FirstOrDefault(p => p.Id == productId);
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.AddItem(product, 1);
            HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
