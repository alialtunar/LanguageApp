using App.Domain.Abstract;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace App.Application.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task<bool> AnyAsync(string id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        ValueTask<T?> GetByIdAsync(int id);
        ValueTask AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
