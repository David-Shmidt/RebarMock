using RebarMock.Models.Dtos;
using RebarMock.Models;

namespace RebarMock.Utils
{
    public class ProductConvertor
    {
        public static ProductDto ConvertToDto(Product product)
        {
            /*var ingredients = new List<Ingredient>();
            foreach(var item in product.Ingredients)
            {
                ingredients.Add(item);
            }*/

            return new ProductDto()
            {
                Id = product.Id,
                Image = product.Image,
                ProductName = product.ProductName,
                Price = product.Price,
                CategoryId = product.CategoryId,
                //Ingredients = product.Ingredients.ToList()
            };
        }

        public static Product ConvertToModel(ProductDto productDto)
        {
            return new Product()
            {
                Image = productDto.Image,
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                //Ingredients = productDto.Ingredients.ToList()
            };
        }
    }
}
