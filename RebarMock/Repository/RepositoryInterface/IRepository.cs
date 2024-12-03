namespace RebarMock.Repository.RepositoryInterface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        Task<ICollection<TEntity>> GetAll();
        TEntity Update(TEntity entity);
        bool Delete(int id);
        TEntity Add(TEntity entity);
    }
}
