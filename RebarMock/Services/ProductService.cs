using RebarMock.Data;
using RebarMock.Models;

namespace RebarMock.Services
{
    public class ProductService
    {
        private IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<Product>> GetAllProducts()
        {
            try
            {
                return await _unitOfWork.Products.GetAll();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddProduct(Product product)
        {
            bool isAdded = false;
            try
            {
                var result = _unitOfWork.Products.Add(product);
                if(result != null)
                {
                    isAdded = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return isAdded;
        }
    }
}
