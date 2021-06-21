using Blog.CleanArchitecture.Domain.Implementations.RepositoryPattern;
using Blog.CleanArchitecture.Domain.Interfaces.IUnitOfWork;
using Blog.CleanArchitecture.Domain.Interfaces.RepositoryPattern;
using Blog.CleanArchitecture.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Domain.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlogContext _context;
        public IBlogPostRepository BlogPost { get; private set; }
        public IPostCommentRepository Comments { get; private set; }

        

        public UnitOfWork(BlogContext context)
        {
            _context = context;
            BlogPost = new BlogPostRepository(_context);
            Comments = new PostCommentRepository(_context);
            
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
