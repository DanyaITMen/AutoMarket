using System.Linq.Expressions;

namespace AutoMarket.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(object id);

        // Додамо новий метод для отримання всіх записів з пов'язаними даними
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}