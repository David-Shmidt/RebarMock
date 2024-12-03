using Microsoft.EntityFrameworkCore;
using RebarMock.Repository.RepositoryInterface;

namespace RebarMock.Repository.RepositoryClass
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _dbContext;
        public Repository(DbContext appDbContext) 
            {
                _dbContext = appDbContext;
            }
        public TEntity Add(TEntity entity)
        {
            try
            {
                 _dbContext.Set<TEntity>().Add(entity);
            }
            catch (Exception)
            {
                return null;
            }
            return entity;
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _dbContext.Set<TEntity>().Find(id);
                _dbContext.Set<TEntity>().Remove(entity);
        
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            try
            {
                return await _dbContext.Set<TEntity>().ToListAsync();
            }
            catch(Exception)
            {
                return null;
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                return _dbContext.Set<TEntity>().Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Update(entity);
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
