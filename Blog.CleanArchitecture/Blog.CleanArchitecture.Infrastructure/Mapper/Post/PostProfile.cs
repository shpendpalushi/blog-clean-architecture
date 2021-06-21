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
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<BlogPost, PostDTO>()
                .ForMember(destionation => destionation.BlogUUID, opt => opt.MapFrom(source => source.BlogUUID))
                .ForMember(destionation => destionation.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(destionation => destionation.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(destionation => destionation.File, src => src.MapFrom(src => src.File))
                .ForMember(destination => destination.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt.ToString("dd.MM.yyyy")))
                .ForMember(destionation => destionation.CreatedUserFullName, opt => opt.MapFrom(src => src.CreatedBy.FullName));
        }
    }
}
