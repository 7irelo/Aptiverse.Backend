using Aptiverse.Application.UserCategories.Dtos;
using Aptiverse.Domain.Models;
using AutoMapper;

namespace Aptiverse.Application.UserCategories.Mapping
{
    public class UserCategoryProfile : Profile
    {
        public UserCategoryProfile()
        {
            CreateMap<UserCategory, UserCategoryDto>().ReverseMap();
        }
    }
}
