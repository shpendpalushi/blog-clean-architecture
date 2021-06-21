using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Infrastructure.DTO
{
    public class PostDTO
    {
        public string BlogUUID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }
        public string CreatedAt { get; set; }
        public string CreatedUserFullName { get; set; }
    }
}
