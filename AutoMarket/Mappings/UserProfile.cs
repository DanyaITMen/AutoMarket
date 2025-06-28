using AutoMapper;
using AutoMarket.Web.DTOs.User;
using AutoMarket.Web.Entities;

namespace AutoMarket.Web.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Всі правила, що стосуються User
            CreateMap<User, UserDto>();
        }
    }
}