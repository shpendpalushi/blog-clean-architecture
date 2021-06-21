using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Infrastructure.CustomValidator
{
    public class EmailValidator<TUser> : IUserValidator<TUser> where TUser : IdentityUser<int>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            if (user.Email == null)
                return Task.FromResult(IdentityResult.Success);
            if (manager.FindByEmailAsync(user.Email) == null)
                return Task.FromResult(IdentityResult.Success);
            return Task.FromResult(
                IdentityResult.Failed(new IdentityError
                {
                    Code = "400",
                    Description = "Email is not unique"
                }));
            
        }
    }
}
