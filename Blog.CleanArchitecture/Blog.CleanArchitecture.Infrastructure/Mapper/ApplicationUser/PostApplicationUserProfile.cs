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
    public class PostApplicationUserProfile : Profile
    {
        public PostApplicationUserProfile()
        {
            CreateMap<RegisterDTO, ApplicationUser>()
                .ForMember(destination => destination.FullName,
                opt => opt.MapFrom(src => src.FullName))
                .ForMember(destination => destination.Email,
                opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.UserName));
        }
    }
}
