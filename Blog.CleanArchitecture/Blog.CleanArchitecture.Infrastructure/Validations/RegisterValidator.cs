using Blog.CleanArchitecture.Infrastructure.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Infrastructure.Validations
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.UserName)
                .MinimumLength(5)
                .WithMessage("Username must be at least 5 characters")
                .MaximumLength(55)
                .WithMessage("Maximum length reached");
            RuleFor(r => r.Password)
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")
                .WithMessage("The password doesn't meet the strength criteria");
            RuleFor(r => r.EmailAddress)
                .EmailAddress()
                .WithMessage("The email format is incorrect");
            RuleFor(r => r.ConfirmPassword)
                .Matches(r => r.Password)
                .WithMessage("The passwords do not match");

        }
    }
}
