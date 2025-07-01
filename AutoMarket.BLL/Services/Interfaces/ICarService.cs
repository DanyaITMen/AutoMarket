using AutoMarket.BLL.DTOs.Car;
using AutoMarket.BLL.Helpers;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoMarket.BLL.Services.Interfaces
{
    // Цей інтерфейс визначає всі операції, які можна виконати з машинами
    public interface ICarService
    {
        Task<CarDto> GetByIdAsync(int id);
        Task<CarDto> CreateAsync(CreateCarDto carDto);
        Task UpdateAsync(int id, UpdateCarDto carDto);
        Task DeleteAsync(int id);
        Task<IEnumerable<CarDto>> GetAllAsync(CarParameters carParameters);
    }
}