using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Data.Entities
{
    public class PostComment
    {
        public int Id { get; set; }
        public Guid CommentUUID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public ApplicationUser CreatedBy { get; set; }
        public string CreatedIP { get; set; }
        public DateTime? LastModified { get; set; }
        public string ModifiedIP { get; set; }
        public ApplicationUser LastModifiedBy { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public BlogPost Post { get; set; }
    }
}
