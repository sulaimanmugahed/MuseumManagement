using MuseumManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MuseumManagement.Application.Interfaces.Repositories
{
    public interface IGenericEntityRepository<T,TId> where T : class 
    {
        Task<T> GetByIdAsync(TId id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);

        void Delete(T entity);
    }
}
