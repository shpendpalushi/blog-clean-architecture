using Blog.CleanArchitecture.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Domain.Interfaces.RepositoryPattern
{
    public interface IPostCommentRepository : IRepository<PostComment>
    {
        Task<IEnumerable<PostComment>> GetPageComments(int index, int pageSize = 10);
    }
}
