using AutoMarket.BLL.DTOs.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMarket.BLL.Services.Interfaces
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