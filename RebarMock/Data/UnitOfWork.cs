using RebarMock.Repository.RepositoryClass;
using RebarMock.Repository.RepositoryInterface;

namespace RebarMock.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IProductRepository Products {get; private set; }
            
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new ProductRepository(context);
        }


        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
