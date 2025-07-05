using Aptiverse.Application.UserCategories.Dtos;
using Aptiverse.Application.Users.Dtos;
using Aptiverse.Application.UserTypes.Dtos;
using Aptiverse.Domain.Models;
using AutoMapper;

namespace Aptiverse.Application.Users.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ForMember(dest => dest.Id, opt => opt.MapFrom(_ => 0)).ReverseMap();
            CreateMap<UserType, UserTypeDto>().ReverseMap();
            CreateMap<UserCategory, UserCategoryDto>().ReverseMap();
        }
    }
}