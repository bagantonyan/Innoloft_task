using EventManager.DAL.Contexts;
using EventManager.DAL.Entities;
using EventManager.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EventManager.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(EventDbContext dbContext) => _dbSet = dbContext.Set<TEntity>();

        public IQueryable<TEntity> GetAll(bool trackChanges)
            => trackChanges ?
            _dbSet :
            _dbSet.AsNoTracking();

        public IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges)
            => trackChanges ?
            _dbSet.Where(expression) :
            _dbSet.Where(expression).AsNoTracking();

        public void Create(TEntity entity)
            => _dbSet.Add(entity);

        public void Update(TEntity entity)
            => _dbSet.Update(entity);

        public void Delete(TEntity entity)
            => _dbSet.Remove(entity);
    }
}