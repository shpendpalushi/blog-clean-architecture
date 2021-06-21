using Blog.CleanArchitecture.Data.Entities;
using Blog.CleanArchitecture.Domain.Interfaces.RepositoryPattern;
using Blog.CleanArchitecture.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Domain.Implementations.RepositoryPattern
{
    public class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(BlogContext context) : base(context)
        {
        }

        public BlogContext BlogContext
        {
            get { return _context as BlogContext;  }
        }

        public async Task<IEnumerable<BlogPost>> GetLatestBlogPosts(int index, int pageSize=10)
        {
             return 
                await BlogContext.Posts
                .OrderBy(p => p.CreatedAt)
                .Skip((index - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<BlogPost>> GetPostsByUser(ApplicationUser user)
        {
            return await BlogContext.Posts
                .Include(p => p.CreatedBy)
                .Where(p => p.CreatedBy == user)
                .ToListAsync();
        }
    }
}
