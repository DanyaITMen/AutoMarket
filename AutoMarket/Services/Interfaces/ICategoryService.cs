using AutoMarket.DTOs.Category;
using AutoMarket.Web.DTOs.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMarket.Web.Services.Interfaces
{
    // Цей інтерфейс визначає всі операції, які можна виконати з категоріями
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto categoryDto);
        Task DeleteAsync(int id);
    }
}