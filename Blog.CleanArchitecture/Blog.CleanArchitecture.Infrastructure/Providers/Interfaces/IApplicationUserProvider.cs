using Blog.CleanArchitecture.Data.Entities;
using Blog.CleanArchitecture.Infrastructure.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Infrastructure.Providers.Interfaces
{
    public interface IApplicationUserProvider
    {

        Task<bool> CreateUserAsync(RegisterDTO model, string password, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager);
        Task<bool> SignInAsync(string username, string password, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager);

    }
}
