using RebarMock.Models;
using RebarMock.Models.Dtos;

namespace RebarMock.Utils
{
    public class IngredientConvertor
    {
        public static IngredientDto ConvertToDto(Ingredient ingredient)
        {
            return new IngredientDto
            {
                Id = ingredient.Id,
                IngredientName = ingredient.IngredientName,
                IsAvialable = ingredient.IsAvialable,
                //Products = ingredient.Products
            };
        }

        public static Ingredient ConvertToModel(IngredientDto ingredient)
        {
            return new Ingredient
            {
                IngredientName = ingredient.IngredientName,
                IsAvialable = ingredient.IsAvialable,
                //Products = ingredient.Products
            };
        }
    }
}
