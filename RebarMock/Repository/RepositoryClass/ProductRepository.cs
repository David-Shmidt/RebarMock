using Microsoft.EntityFrameworkCore;
using RebarMock.Models;
using RebarMock.Repository.RepositoryInterface;

namespace RebarMock.Repository.RepositoryClass
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }
    }
}
