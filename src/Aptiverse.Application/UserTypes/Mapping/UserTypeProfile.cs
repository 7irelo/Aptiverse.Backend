using Aptiverse.Application.UserTypes.Dtos;
using Aptiverse.Domain.Models;
using AutoMapper;

namespace Aptiverse.Application.UserTypes.Mapping
{
    public class UserTypeProfile : Profile
    {
        public UserTypeProfile()
        {
            CreateMap<UserType, UserTypeDto>().ReverseMap();
        }
    }
}
