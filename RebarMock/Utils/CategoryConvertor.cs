using RebarMock.Models;
using RebarMock.Models.Dtos;

namespace RebarMock.Utils
{
    public class CategoryConvertor
    {
        public static CategoryDto ConvertToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };
        }

        public static Category ConvertToModel(CategoryDto categoryDto, int categoryId)
        {
            return new Category
            {
                Id = categoryId,
                CategoryName = categoryDto.CategoryName
            };
        }
    }
}
