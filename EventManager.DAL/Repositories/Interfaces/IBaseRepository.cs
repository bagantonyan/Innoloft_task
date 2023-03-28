using EventManager.DAL.Entities.Interfaces;
using System.Linq.Expressions;

namespace EventManager.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        IQueryable<TEntity> GetAll(bool trackChanges);
        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}