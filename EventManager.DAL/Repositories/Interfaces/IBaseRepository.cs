using EventManager.DAL.Entities;
using System.Linq.Expressions;

namespace EventManager.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll(bool trackChanges);
        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
    }
}