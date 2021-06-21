using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Data.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public Guid BlogUUID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string File { get; set; }
        public DateTime CreatedAt { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public string CreatedIP { get; set; }
        public DateTime? LastModified { get; set; }
        public ApplicationUser LastModifiedBy { get; set; }
        public string LastModifiedIP { get; set; }
        public ICollection<PostComment> Comments { get; set; }
    }
}
