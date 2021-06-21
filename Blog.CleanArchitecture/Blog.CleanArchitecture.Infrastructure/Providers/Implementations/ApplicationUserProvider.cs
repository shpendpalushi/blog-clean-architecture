using AutoMapper;
using Blog.CleanArchitecture.Data.Entities;
using Blog.CleanArchitecture.Domain.Implementations.Identity;
using Blog.CleanArchitecture.Domain.Interfaces.Identity;
using Blog.CleanArchitecture.Domain.Interfaces.IUnitOfWork;
using Blog.CleanArchitecture.Infrastructure.DTO;
using Blog.CleanArchitecture.Infrastructure.Providers.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Infrastructure.Providers.Implementations
{
    public class ApplicationUserProvider : IApplicationUserProvider
    {
        private readonly IApplicationUserActions _actions;
        private readonly IMapper _mapper;

        public ApplicationUserProvider(IApplicationUserActions actions, IMapper mapper) 
        {
            _actions = actions;
            _mapper = mapper;

        }

        public async Task<bool> CreateUserAsync(RegisterDTO model, string password, 
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            ApplicationUser user = _mapper.Map<RegisterDTO, ApplicationUser>(model);
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return true;
            }
            return false;

        }

        public async Task<bool> SignInAsync(string username, string password,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            var user = await userManager.FindByEmailAsync(username);
            if (user == null)
                user = await userManager.FindByNameAsync(username);
            if (user == null)
                return false;
            var logged = await signInManager.PasswordSignInAsync(user, password, false, true);
            return logged.Succeeded;
        }
    }
}
