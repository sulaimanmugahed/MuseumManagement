using Microsoft.EntityFrameworkCore;
using MuseumManagement.Application.DTOs;
using MuseumManagement.Application.Interfaces.Repositories;
using MuseumManagement.Domain.Common;
using MuseumManagement.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Persistence.Repositories
{
    
    public class GenericEntityRepository<T,TId>(ApplicationDbContext dbContext)
        : IGenericEntityRepository<T, TId> where T : class
    {
         
        public async Task<T> GetByIdAsync(TId id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return entity;
        }


        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbContext
                 .Set<T>()
                 .ToListAsync();
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = dbContext.Set<T>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }

        protected async Task<PagenationResponseDto<TEntity>> Paged<TEntity>(IQueryable<TEntity> query, int pageNumber, int pageSize)
        {
            var count = await query.CountAsync();

            var pagedResult = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new(pagedResult, count);
        }
     

    }
}
