using Blog.CleanArchitecture.Data.Entities;
using Blog.CleanArchitecture.Domain.Interfaces.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Domain.Implementations.Identity
{
    public class ApplicationUserActions : IApplicationUserActions
    {
        public async Task<IdentityResult> CreateUserAsync(UserManager<ApplicationUser> _userManager,
            SignInManager<ApplicationUser> _signInManager,
            ApplicationUser user, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(user, password);
            await _signInManager.SignInAsync(user, true);
            return result;
        }

    }
}
