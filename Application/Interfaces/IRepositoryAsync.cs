using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepositoryAsync<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
