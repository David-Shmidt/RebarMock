using RebarMock.Models;

namespace RebarMock.Repository.RepositoryInterface
{
    public interface IProductRepository : IRepository<Product>
    {
        IQueryable<Product> GetProductsByCategoryId(int categoryId);
    }
}
