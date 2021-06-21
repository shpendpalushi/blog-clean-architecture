using Blog.CleanArchitecture.Data.Entities;
using Blog.CleanArchitecture.Domain.Implementations.RepositoryPattern;
using Blog.CleanArchitecture.Domain.Implementations.UnitOfWork;
using Blog.CleanArchitecture.Domain.Interfaces.IUnitOfWork;
using Blog.CleanArchitecture.Domain.Interfaces.RepositoryPattern;
using Blog.CleanArchitecture.Domain.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Blog.CleanArchitecture.Domain.Interfaces.Identity;
using Blog.CleanArchitecture.Domain.Implementations.Identity;
using AutoMapper;
using Blog.CleanArchitecture.Infrastructure.Mapper;
using Blog.CleanArchitecture.Infrastructure.Providers.Implementations;
using Blog.CleanArchitecture.Infrastructure.Providers.Interfaces;
using Blog.CleanArchitecture.Infrastructure.CustomValidator;

namespace Blog.CleanArchitecture.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositoryPatternBlog(this IServiceCollection services)
        {
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IPostCommentRepository, PostCommentRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddIdentityBlog(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddEntityFrameworkStores<BlogContext>()
                    .AddDefaultTokenProviders()
                    .AddUserValidator<EmailValidator<ApplicationUser>>();
        }

        public static void AddDbConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BlogContext>(options =>
            options.UseSqlServer(connectionString));
        }

        public static void AddIdentitySuplement(this IServiceCollection services)
        {
            services.AddScoped<IApplicationUserActions, ApplicationUserActions>();
        }

        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile(new PostApplicationUserProfile());
                mapperConfig.AddProfile(new CommentProfile());
                mapperConfig.AddProfile(new PostProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public  static void AddProviders(this IServiceCollection services)
        {
            services.AddScoped<SignInManager<ApplicationUser>>();
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddTransient<IApplicationUserActions, ApplicationUserActions>();
            services.AddScoped<IApplicationUserProvider, ApplicationUserProvider>();
        }
    }
}
