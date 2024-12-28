using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RebarMock.Data;
using RebarMock.Models;
using RebarMock.Models.Dtos;
using RebarMock.Utils;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RebarMock.Services
{
    public class ProductService
    {
        private IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<ProductDto>> GetAllProducts()
        {
            ICollection<ProductDto> products = new List<ProductDto>();
            try
            {
                var query = _unitOfWork.Products.GetProductsWithIngredients();
                ICollection<Product> items = await query.ToListAsync();
                foreach(var item in items)
                {
                    products.Add(ProductConvertor.ConvertToDto(item));
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return products;
        }

        public ProductDto GetProductById(int productId)
        {
            try
            {
                Product product = _unitOfWork.Products.GetById(productId);
                if(product != null)
                {
                    return ProductConvertor.ConvertToDto(product);
                }
                else
                {
                    return null;
                }
                
            }
            catch(Exception ex) 
            {
                throw ex; 
            }
        }

        public bool AddProduct(ProductDto productDto)
        {
            bool isAdded = false;
            Product product = ProductConvertor.ConvertToModel(productDto);
            try
            {
                var result = _unitOfWork.Products.Add(product);
                if(result != null)
                {
                    isAdded = true;
                }
                _unitOfWork.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return isAdded;
        }

        public bool UpdateProduct(ProductDto productDto, int productId)
        {
            bool updated = false;
            Product product = ProductConvertor.ConvertToModel(productDto);
            product.Id = productId;
            try
            {
                var result = _unitOfWork.Products.Update(product);
                if(result != null)
                {
                    updated = true;
                }
                _unitOfWork.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return updated;
        }

        public bool UpdateProductImage(string image, int productId)
        {
            bool updated = false;
            try
            {
                Product product = _unitOfWork.Products.GetById(productId);
                if(product != null)
                {
                    product.Image = image;
                    var result = _unitOfWork.Products.Update(product);
                    if(result != null)
                    {
                        updated = true;
                        _unitOfWork.SaveChanges();
                    }
                }
                return updated;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveProductById(int productId)
        {
            try
            {
                Product product = _unitOfWork.Products.GetById(productId);
                if(product != null)
                {
                    foreach(Ingredient ingredient in product.Ingredients)
                    {
                        ingredient.Products.Remove(product);
                    }
                }
                bool isDeleted =  _unitOfWork.Products.Delete(productId);
                if (isDeleted)
                {
                    _unitOfWork.SaveChanges();
                }
                return isDeleted;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<ProductDto>> GetProductsByCategoryId(int categoryId)
        {
            try
            {
                var query = _unitOfWork.Products.GetProductsByCategoryId(categoryId);
                ICollection<Product> products = await query.ToListAsync();
                ICollection<ProductDto> productDtos = new List<ProductDto>();
                if (products != null)
                {
                    foreach (Product product in products)
                    {
                        productDtos.Add(ProductConvertor.ConvertToDto(product));
                    }
                }
                return productDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public (bool,Product) CreateProductWithIngredients(ProductIngredientsDto productDto)
        {
            try
            {
                var query = _unitOfWork.Ingredients.GetFilteredIngredientsById(productDto.IngredientsIds);
                List<Ingredient> ingredients = query.ToList();
                bool isCreated = false;
                Product productAdded = new Product();
                if(!ingredients.IsNullOrEmpty())
                {
                    Product product = ProductConvertor.ConvertToModel(productDto, ingredients);
                    productAdded = _unitOfWork.Products.Add(product);
                    if(productAdded != null)
                    {
                        isCreated = true;
                        _unitOfWork.SaveChanges();
                    }
                }
                return (isCreated, productAdded);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
