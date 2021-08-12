using Microsoft.AspNetCore.Identity;
using CardGameSite.DAL.Entities;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;

namespace CardGameSite.BLL.Infrastructure
{
    public class AppRoleManager : RoleManager<Role>
    {
        public AppRoleManager(  IRoleStore<Role> store,
                                IEnumerable<IRoleValidator<Role>> roleValidators, 
                                ILookupNormalizer keyNormalizer, 
                                IdentityErrorDescriber errors,
                                ILogger<RoleManager<Role>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        { }

        public class RoleT : Role { }
    }
}
