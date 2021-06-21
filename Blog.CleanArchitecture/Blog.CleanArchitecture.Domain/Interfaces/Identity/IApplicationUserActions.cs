using Blog.CleanArchitecture.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Domain.Interfaces.Identity
{
    public interface IApplicationUserActions
    {
        Task<IdentityResult> CreateUserAsync(UserManager<ApplicationUser> _userManager,
           SignInManager<ApplicationUser> _signInManager,
           ApplicationUser user, string password);
    }
}
