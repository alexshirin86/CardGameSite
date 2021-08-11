using Microsoft.AspNetCore.Identity;
using CardGameSite.DAL.Entities;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

namespace CardGameSite.BLL.Infrastructure
{
    public class AppSignInManager : SignInManager<User>
    {
        public AppSignInManager(   UserManager<User> userManager, 
                                    IHttpContextAccessor contextAccessor, 
                                    IUserClaimsPrincipalFactory<User> claimsFactory, 
                                    IOptions<IdentityOptions> optionsAccessor, 
                                    ILogger<SignInManager<User>> logger, 
                                    IAuthenticationSchemeProvider schemes, 
                                    IUserConfirmation<User> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation) 
        { }
    }
}
