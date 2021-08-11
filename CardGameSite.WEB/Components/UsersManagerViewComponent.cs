using Microsoft.AspNetCore.Identity;
using CardGameSite.WEB.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CardGameSite.BLL.Infrastructure;
using AutoMapper;

namespace CardGameSite.WEB.Components
{
    public class UsersManagerViewComponent : ViewComponent
    {
        AppUserManager _userManager;
        private IMapper _mapper;

        public UsersManagerViewComponent(AppUserManager userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View(_userManager.Users.ToList());
        }

        public IViewComponentResult Create() => View();

        [HttpPost]
        public async Task<IViewComponentResult> Create(RegisterUser model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUserManager.UserType { Email = model.Email, UserName = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return View();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IViewComponentResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return View();
            }
            EditUser model = new EditUser { Id = user.Id, Email = user.Email};
            return View(model);
        }

        [HttpPost]
        public async Task<IViewComponentResult> Edit(EditUser model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id.ToString());
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return View();
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IViewComponentResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return View();
        }
    }
}
 