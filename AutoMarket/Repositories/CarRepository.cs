using AutoMarket.Web.Data;
using AutoMarket.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoMarket.Web.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(AutoMarketDbContext context) : base(context) { }

        public async Task<IEnumerable<Car>> GetByBrandAsync(string brand)
        {
            return await _dbSet
                                 .Include(c => c.Category)
                                 .Include(c => c.User)
                                 .Where(c => c.Brand.ToLower() == brand.ToLower())
                                 .ToListAsync();
        }

        public async Task<Car> GetByIdWithDetailsAsync(int id)
        {
            return await _dbSet
                                 .Include(c => c.Category) // Включаємо категорію
                                 .Include(c => c.User)     // Включаємо користувача
                                 .FirstOrDefaultAsync(c => c.Id == id); // Знаходимо по ID
        }
    }
}