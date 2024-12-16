using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RebarMock.Data;
using RebarMock.Models;
using RebarMock.Models.Dtos;
using RebarMock.Services;
using RebarMock.Utils;

namespace RebarMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService _productService;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _productService = new ProductService(unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductDto>>> GetAllProducts()
        {
            ICollection<ProductDto> products = new List<ProductDto>();
            try
            {
                products = await _productService.GetAllProducts();
            }
            catch
            {
                throw new Exception("Cannot retrieve Products");
            }

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public ActionResult<ProductDto> GetProductById(int productId)
        {
            try
            {
                ProductDto product = _productService.GetProductById(productId);
                if(product != null)
                {
                    return Ok(product);
                }
                else
                {
                    return NotFound("Could not retrieve product with id: " + productId);
                }
            }
            catch(Exception ex)
            {
                return BadRequest("Request failed for product with id: " + productId + " " + ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct([FromBody]ProductDto product)
        {
            try
            {
                bool sucess =  _productService.AddProduct(product);
                if(sucess)
                {
                    return Ok(product);
                }
                else
                {
                    return BadRequest("Could Not Add"); 
                }
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.Message);
            }
        }

        [HttpPut("productId")]
        public ActionResult<ProductDto> UpdateProduct(ProductDto product, int productId)
        {
            try
            {
                bool sucess =  _productService.UpdateProduct(product, productId);
                if(sucess)
                {
                    return Ok(product);
                }
                else
                {
                    return BadRequest("Could Not Update"); 
                }
            }
            catch (Exception ex)
            {
                return NotFound("Error: " + ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        public ActionResult<bool> RemoveProductById(int productId)
        {
            try
            {
                bool isDeleted = _productService.RemoveProductById(productId);
                if (isDeleted)
                {
                    return Ok("Product with id: " + productId + " deleted succesfuly");
                }
                else
                {
                    return NotFound("Could not find product with id: " + productId);
                }
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byCategory/{categoryId}")]
        public async Task<ActionResult<ICollection<ProductDto>>> GetProductsByCategoryId(int categoryId) 
        {
            ICollection<ProductDto> products = await _productService.GetProductsByCategoryId(categoryId);   
            return Ok(products);
        }

        [HttpPost("productIngredients")]
        public ActionResult<Product> CreateProductWithIngredients([FromBody] ProductIngredientsDto productDto) 
        {
            try
            {
                (bool isCreated, Product product) = _productService.CreateProductWithIngredients(productDto);
                if(isCreated)
                {
                    List<string> ingredientsNames = new List<string>();
                    foreach(var item in product.Ingredients)
                    {
                        ingredientsNames.Add(item.IngredientName);
                    }
                    return Ok(new
                    {
                        
                        ProductName = product.ProductName,
                        Price = product.Price,
                        Ingredients = ingredientsNames
                    });
                }
                else
                {
                    return BadRequest("Could not add product");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
