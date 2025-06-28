using AutoMarket.Web.DTOs.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMarket.Web.Services.Interfaces
{
    // Цей інтерфейс визначає всі операції, які можна виконати з машинами
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllAsync();
        Task<CarDto> GetByIdAsync(int id);
        Task<CarDto> CreateAsync(CreateCarDto carDto);
        Task UpdateAsync(int id, UpdateCarDto carDto);
        Task DeleteAsync(int id);
    }
}