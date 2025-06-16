using AutoMarket.Web.Entities;

namespace AutoMarket.Web.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Car> Cars { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<User> Users { get; }
        Task<int> SaveChangesAsync();
    }
}