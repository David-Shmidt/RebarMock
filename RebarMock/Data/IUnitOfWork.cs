using RebarMock.Repository.RepositoryInterface;

namespace RebarMock.Data
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        int SaveChanges();

    }
}
