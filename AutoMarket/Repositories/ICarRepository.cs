using AutoMarket.Web.Entities;
using System.Linq.Expressions;

namespace AutoMarket.Web.Repositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<IEnumerable<Car>> GetByBrandAsync(string brand);
        Task<Car> GetByIdWithDetailsAsync(int id);
    }
}