using AutoMarket.DAL.Repositories.Interfaces;
using AutoMarket.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoMarket.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AutoMarketDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(AutoMarketDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(object id) => await _dbSet.FindAsync(id);

        // Оновлюємо GetAllAsync для підтримки Include
        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbSet;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _dbSet.Where(predicate).ToListAsync();

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public void Delete(T entity) => _dbSet.Remove(entity);
    }
}