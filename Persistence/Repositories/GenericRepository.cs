using Application.Interfaces;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IRepositoryAsync<T> where T : class
    {
        private readonly ProductsContext _context;

        public GenericRepository(ProductsContext  context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                IQueryable<T> QueryEntity = filter == null ? _context.Set<T>() : _context.Set<T>().Where(filter);
                return QueryEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            try
            {
                var entity = await _context.Set<T>().FirstOrDefaultAsync(filter);
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
