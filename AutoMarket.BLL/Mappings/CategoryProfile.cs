using AutoMapper;
using AutoMarket.BLL.DTOs.Category;
using AutoMarket.DAL.Entities;

namespace AutoMarket.BLL.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // Всі правила, що стосуються Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
        }
    }
}