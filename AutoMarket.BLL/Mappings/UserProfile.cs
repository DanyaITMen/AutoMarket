using AutoMapper;
using AutoMarket.BLL.DTOs.User;
using AutoMarket.DAL.Entities;

namespace AutoMarket.BLL.Mappings
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