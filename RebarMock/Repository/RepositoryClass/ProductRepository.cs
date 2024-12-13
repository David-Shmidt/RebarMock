using Microsoft.EntityFrameworkCore;
using RebarMock.Data;
using RebarMock.Models;
using RebarMock.Repository.RepositoryInterface;

namespace RebarMock.Repository.RepositoryClass
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context) { }

        protected ApplicationDbContext _appContext{get{return _dbContext as ApplicationDbContext;} }


        public IQueryable<Product> GetProductsByCategoryId(int categoryId)
        {
            var query = _appContext.Products.Where(p => p.CategoryId == categoryId);
            return query;
        }
    }
}
