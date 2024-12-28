using RebarMock.Models.Dtos;
using RebarMock.Models;
using System.Buffers.Text;

namespace RebarMock.Utils
{
    public class ProductConvertor
    {
        public static ProductDto ConvertToDto(Product product)
        {

            //Convert the ingredient object into a simple ingredient string to store the name
            var ingredients = new List<string>();
            foreach (var item in product.Ingredients)
            {
                ingredients.Add(item.IngredientName);
            }

            byte[] image = new byte[0];
            //extract the actual image using image path
            if (File.Exists(product.Image))
            {
                image = File.ReadAllBytes(product.Image);
            }

            return new ProductDto()
            {
                Id = product.Id,
                Image = Convert.ToBase64String(image),
                ProductName = product.ProductName,
                Price = product.Price,
                CategoryId = product.CategoryId,
                Ingredients = ingredients
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

        public static Product ConvertToModel(ProductIngredientsDto productDto, List<Ingredient> ingredients)
        {
            return new Product
            {
                ProductName = productDto.ProductName,
                Price = productDto.Price,
                CategoryId = productDto.CategoryId,
                Ingredients = ingredients
            };
        }
    }
}
