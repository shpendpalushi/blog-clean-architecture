using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Infrastructure.DTO
{
    public class CommentDTO
    {
        public string CommentUUID { get; set; }
        public string Content { get; set; }
        public string CreatedAt { get; set; }
        public string FullNameOfUser { get; set; }
        public string BlogPostUUID { get; set; }
    }
}
