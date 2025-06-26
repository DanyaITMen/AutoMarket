using AutoMarket.Web.Entities;
using System;

namespace AutoMarket.Web.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Car> Cars { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<User> Users { get; }
        ICarRepository CarRepository { get; } 
        Task<int> SaveChangesAsync();
    }
}