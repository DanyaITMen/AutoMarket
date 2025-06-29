using AutoMarket.Web.Entities;
using System.Linq.Expressions;

namespace AutoMarket.Repositories.Interfaces
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<IEnumerable<Car>> GetByBrandAsync(string brand);
        Task<Car> GetByIdWithDetailsAsync(int id);
    }
}