using AutoMarket.DAL.Entities;
using AutoMarket.DAL.Data;
using System;

namespace AutoMarket.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        AutoMarketDbContext Context { get; }

        IGenericRepository<Car> Cars { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<User> Users { get; }
        ICarRepository CarRepository { get; } 
        Task<int> SaveChangesAsync();
    }
}