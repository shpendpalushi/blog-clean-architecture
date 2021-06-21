using Blog.CleanArchitecture.Domain.Implementations.RepositoryPattern;
using Blog.CleanArchitecture.Domain.Interfaces.RepositoryPattern;
using Blog.CleanArchitecture.Infrastructure.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Infrastructure.Validations
{
    public class CommentValidator : AbstractValidator<CommentDTO>
    {
        private readonly IBlogPostRepository _blogRepo;

        public CommentValidator(IBlogPostRepository blogRepo)
        {
            _blogRepo = blogRepo;
        }

        public CommentValidator()
        {
            RuleFor(comment => comment.Content)
                .MinimumLength(1)
                .WithMessage("Comment content cannot be empty")
                .MaximumLength(525)
                .WithMessage("Maximum length exceeded");
            RuleFor(comment => comment.BlogPostUUID)
                .Must(uuid => 
                {
                    bool exists = ExistAsBlogPost(uuid);
                    return exists;
                })
                .WithMessage("There is no blog post like this");
        }


        private bool ExistAsBlogPost(string uuid)
        {
            var blog =  _blogRepo
                .Find(b => b.BlogUUID.ToString() == uuid)
                .FirstOrDefault();
            if (blog != null)
                return true;
            return false;
        }
    }
}
