using AutoMarket.Web.DTOs.Car;
using AutoMarket.Web.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMarket.Web.Helpers;

namespace AutoMarket.Web.Services.Interfaces
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