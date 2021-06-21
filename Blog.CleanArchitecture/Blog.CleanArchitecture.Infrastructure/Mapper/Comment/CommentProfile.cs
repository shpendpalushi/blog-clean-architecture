using AutoMapper;
using Blog.CleanArchitecture.Data.Entities;
using Blog.CleanArchitecture.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.CleanArchitecture.Infrastructure.Mapper
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<PostComment, CommentDTO>()
                .ForMember(destination => destination.CommentUUID,
                opt => opt.MapFrom(src => src.CommentUUID))
                .ForMember(destination => destination.Content,
                opt => opt.MapFrom(src => src.Content))
                .ForMember(destination => destination.CreatedAt,
                opt => opt.MapFrom(src => src.CreatedAt.ToString("dd.MM.yyyy")))
                .ForMember(destination => destination.FullNameOfUser,
                opt => opt.MapFrom(src => src.CreatedBy.FullName))
                .ForMember(destination => destination.BlogPostUUID,
                opt => opt.MapFrom(src => src.Post.BlogUUID));

        }
    }
}
