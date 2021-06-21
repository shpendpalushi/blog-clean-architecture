using Blog.CleanArchitecture.Infrastructure.DTO;
using Blog.CleanArchitecture.Infrastructure.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Infrastructure.Validations
{
    public class PostValidator : AbstractValidator<PostDTO>
    {
        public PostValidator()
        {
            RuleFor(post => post.Title)
                .MinimumLength(1)
                .WithMessage("Title should have content")
                .MaximumLength(255)
                .WithMessage("Reached the maximum length");
            RuleFor(post => post.Content)
                .MinimumLength(1)
                .WithMessage("Content cannot be empty")
                .MaximumLength(500)
                .WithMessage("Reached the maximum length");
            RuleFor(post => post.File)
                .Must(file => BeAValidFileType(file) != FileExtensions.undefined);
        }

        private FileExtensions BeAValidFileType(string fileName)
        {
            string extension = fileName.Substring(fileName.LastIndexOf("."), fileName.Length - fileName.LastIndexOf("."));
            switch (extension) 
            {
                case ".png":
                    return FileExtensions.png;
                case ".jpg":
                    return FileExtensions.jpg;
                case ".jpeg":
                    return FileExtensions.jpg;
                case ".gif":
                    return FileExtensions.gif;
            }
            return FileExtensions.undefined;

        }
    }
}
