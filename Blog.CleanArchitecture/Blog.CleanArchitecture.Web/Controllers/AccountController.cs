using Blog.CleanArchitecture.Data.Entities;
using Blog.CleanArchitecture.Domain.Implementations.Identity;
using Blog.CleanArchitecture.Infrastructure.DTO;
using Blog.CleanArchitecture.Infrastructure.Providers.Interfaces;
using Blog.CleanArchitecture.Infrastructure.Validations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApplicationUserProvider _provider;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IApplicationUserProvider provider, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _provider = provider;
        }

        public IActionResult Register()
        {
            return View();
        }

        public async  Task<IActionResult> Login()
        {
            await _signInManager.SignOutAsync();
            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> Register(RegisterDTO model)
        {
            try
            {
                var validator =  new RegisterValidator();
                var result = validator.Validate(model);
                if (result.IsValid)
                {
                    bool wasRegistered = await _provider.CreateUserAsync(model, model.Password, _userManager, _signInManager);
                    if (wasRegistered)
                        return Json(new { success = true }, new JsonSerializerOptions
                        {
                            WriteIndented = true
                        });
                }
                return Unauthorized();
            }
            catch(Exception exc)
            {
                return Json(new { success = false}, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
        }
        [HttpPost]
        public async Task<IActionResult> TryLogin(string userName, string pass)
        {
            bool succeded = await _provider.SignInAsync(userName, pass, _userManager, _signInManager);
            if (succeded)
                return Json(new { success = true }, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            return Unauthorized();
        }
    }
}
