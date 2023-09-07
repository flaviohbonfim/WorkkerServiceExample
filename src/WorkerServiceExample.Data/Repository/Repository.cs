using Microsoft.EntityFrameworkCore;
using WorkerServiceExample.Data.Entities;

namespace WorkerServiceExample.Data.Repository
{
    public class Repository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }
        
        public IEnumerable<TEntity> GetActiveItems()
        {
            return _dbContext.Set<TEntity>().Where(e => e.DeletedAt == null).ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }
        public void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CreatedAt = DateTime.UtcNow;
            }
            
            _dbContext.Set<TEntity>().AddRange(entities);
            _dbContext.SaveChanges(); 
        }


        public void Update(TEntity entity)
        {
            entity.ModifiedAt = DateTime.UtcNow;
            _dbContext.Set<TEntity>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.DeletedAt = DateTime.UtcNow;
                _dbContext.Set<TEntity>().Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
            _dbContext.SaveChanges();
        }
    }
}
