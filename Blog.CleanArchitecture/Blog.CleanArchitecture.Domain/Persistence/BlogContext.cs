using Blog.CleanArchitecture.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Blog.CleanArchitecture.Domain.Persistence
{
    public class BlogContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, 
        IdentityUserClaim<int>, ApplicationUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {

        }
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<PostComment> Comments { get; set; }
    }
}
