using AutoMarket.Web.Data;
using AutoMarket.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoMarket.Web.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(AutoMarketDbContext context) : base(context) { }

        public async Task<IEnumerable<Car>> GetByBrandAsync(string brand)
        {
            return await _context.Cars
                                 .Where(c => c.Brand.ToLower() == brand.ToLower())
                                 .ToListAsync();
        }
    }
}