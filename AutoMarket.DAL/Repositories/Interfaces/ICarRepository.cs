using AutoMarket.DAL.Entities;
using System.Linq.Expressions;

namespace AutoMarket.DAL.Repositories.Interfaces
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<IEnumerable<Car>> GetByBrandAsync(string brand);
        Task<Car> GetByIdWithDetailsAsync(int id);
    }
}