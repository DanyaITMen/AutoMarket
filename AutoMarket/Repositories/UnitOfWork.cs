using AutoMarket.Repositories.Interfaces;
using AutoMarket.Web.Data;
using AutoMarket.Web.Entities;
using AutoMarket.Web.Repositories;

namespace AutoMarket.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AutoMarketDbContext _context;
        private IGenericRepository<Car> _cars;
        private IGenericRepository<Category> _categories;
        private IGenericRepository<User> _users;
        private ICarRepository _carRepository;

        public UnitOfWork(AutoMarketDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Car> Cars => _cars ??= new GenericRepository<Car>(_context);
        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);
        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);
        public ICarRepository CarRepository => _carRepository ??= new CarRepository(_context);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();

        public AutoMarketDbContext Context => _context;
    }
}