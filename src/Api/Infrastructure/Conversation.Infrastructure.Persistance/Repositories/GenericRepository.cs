using Conversation.Api.Application.Interfaces.Repositories;
using Conversation.Api.Domain.Models;
using Conversation.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Infrastructure.Persistance.Repositories
{
    public  class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        private readonly DbContext _context;

        public  GenericRepository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected DbSet<TEntity> _entity => _context.Set<TEntity>();

        public virtual async Task Add(TEntity entity)
        {
            _entity.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<int> AddAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual int AddOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> AddOrUpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual int AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual IQueryable<TEntity> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public virtual Task BulkAdd(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual Task BulkDelete(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual Task BulkDelete(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public virtual Task BulkDeleteById(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public virtual Task BulkUpdate(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public virtual int Delete(Guid id)
        {
            var entity = _entity.Find(id);
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Entry(entity).State= EntityState.Deleted;
            return _context.SaveChanges();
        }

        public virtual int Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _entity.Attach(entity);
            }
            _entity.Remove(entity);
            return _context.SaveChanges();
        }

        public virtual async Task<int> DeleteAsync(Guid id)
        {
            var entity = _entity.Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Entry(entity).State = EntityState.Deleted;
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _entity.Attach(entity);
            }
            _entity.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual bool DeleteRange(Expression<Func<TEntity, bool>> expression)
        {
            _context.RemoveRange(_entity.Where(expression));
            return _context.SaveChanges() > 0;
        }

        public virtual async Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> expression)
        {
            _context.RemoveRange(_entity.Where(expression));
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<List<TEntity>> GetAll(bool noTracking = true)
        {
            if (!noTracking)
            {
                return await _entity.AsNoTracking().ToListAsync();
            }
            return await _entity.ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> expression, bool noTracking = true)
        {
            if (!noTracking)
            {
                return await _entity.Where(expression).AsNoTracking().ToListAsync();
            }
            return await _entity.Where(expression).ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAsQueryable(Expression<Func<TEntity, bool>> expression, bool noTracking = true)
        {
            var query = _entity;
            if (!noTracking)
            {
                query.AsNoTracking();
            }
            query.Where(expression);
            return query;
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid Id, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            var found = _entity.Find(Id);
            if(found == null)
            {
                return null;
            }
            if (noTracking)
                _context.Entry(found).State = EntityState.Detached;
            if(includes != null)
            {
                foreach (var include in includes)
                {
                    _context.Entry(found).Reference(include).Load();
                }
            }
            return found;
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity=await _entity.FirstOrDefaultAsync(expression);
            if(entity == null)
            {
                return null;
            }
            return entity;
        }

        public virtual int Update(TEntity entity)
        {
            _entity.Attach(entity).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            _entity.Attach(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
