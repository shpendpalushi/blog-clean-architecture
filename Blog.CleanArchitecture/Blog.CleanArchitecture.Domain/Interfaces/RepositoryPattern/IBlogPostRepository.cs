using Blog.CleanArchitecture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Domain.Interfaces.RepositoryPattern
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {
        Task<IEnumerable<BlogPost>> GetLatestBlogPosts(int index, int pageSize=10);
        Task<IEnumerable<BlogPost>> GetPostsByUser(ApplicationUser user);
    }
}
