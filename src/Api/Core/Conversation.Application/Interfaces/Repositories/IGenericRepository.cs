using Conversation.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Api.Application.Interfaces.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<int> AddAsync(TEntity entity);
        Task<int> AddRangeAsync(IEnumerable<TEntity> entities);
        Task Add(TEntity entity);
        int AddRange(IEnumerable<TEntity> entities);


        Task<int> UpdateAsync(TEntity entity);
        int Update(TEntity entity);


        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(TEntity entity);
        int Delete(Guid id);
        int Delete(TEntity entity);
        Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> expression);
        bool DeleteRange(Expression<Func<TEntity, bool>> expression);


        Task<int> AddOrUpdateAsync(TEntity entity);
        int AddOrUpdate(TEntity entity);


        IQueryable<TEntity> AsQueryable();
        Task<List<TEntity>> GetAll(bool noTracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity,bool>> expression);

        Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression, bool noTracking = true);
        Task<TEntity> GetByIdAsync(Guid Id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetAsQueryable(Expression<Func<TEntity, bool>> expression, bool noTracking = true);



        Task BulkDeleteById(IEnumerable<Guid> ids);
        Task BulkDelete(IEnumerable<TEntity> entities);
        Task BulkDelete(Expression<Func<TEntity, bool>> expression);
        Task BulkUpdate(IEnumerable<TEntity> entities);
        Task BulkAdd(IEnumerable<TEntity> entities);

    }
}
