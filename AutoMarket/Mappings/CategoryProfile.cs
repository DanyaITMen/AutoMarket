using AutoMapper;
using AutoMarket.DTOs.Category;
using AutoMarket.Web.DTOs.Category;
using AutoMarket.Web.Entities;

namespace AutoMarket.Web.Mappings
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