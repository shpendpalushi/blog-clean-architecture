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
    public class PostCommentRepository : Repository<PostComment>, IPostCommentRepository
    {
        public PostCommentRepository(BlogContext context) : base(context)
        {

        }

        public async Task<IEnumerable<PostComment>> GetPageComments(int index, int pageSize = 10)
        {
            return await BlogContext.Comments
                .Skip((index - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public BlogContext BlogContext
        {
            get
            {
                return _context as BlogContext;
            }
        }
    }
}
