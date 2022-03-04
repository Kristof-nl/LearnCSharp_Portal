using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generics
{
    public interface IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        public IQueryable<TEntity> GetAll();
        public Task<TEntity> GetById(int id);
        public Task<TEntity> GetByIdWithTracking(int id);
        public Task<TEntity> Create(TEntity entity);
        public Task Update(TEntity entity);
        public Task Delete(int id);
    }

    public interface IEntity
    {
        int Id { get; set; }
    }
}