using Blog.CleanArchitecture.Domain.Interfaces.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Domain.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBlogPostRepository BlogPost { get; }
        IPostCommentRepository Comments { get; }
        int Complete();
    }
}
