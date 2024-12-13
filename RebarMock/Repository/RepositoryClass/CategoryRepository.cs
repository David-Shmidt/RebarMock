using Microsoft.EntityFrameworkCore;
using RebarMock.Models;
using RebarMock.Repository.RepositoryInterface;

namespace RebarMock.Repository.RepositoryClass
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        public CategoryRepository(DbContext context) : base(context) { }
    }
}
