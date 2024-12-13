using RebarMock.Data;
using RebarMock.Models;
using RebarMock.Models.Dtos;
using RebarMock.Utils;

namespace RebarMock.Services
{
    public class CategoryService
    {
        private IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<CategoryDto>> GetAllCategories()
        {
            try
            {
                ICollection<Category> categories = await _unitOfWork.Categories.GetAll();
                ICollection<CategoryDto> categoryDtos = new List<CategoryDto>();
                if(categories != null)
                {
                    foreach(Category category in categories)
                    {
                        categoryDtos.Add(CategoryConvertor.ConvertToDto(category));
                    }
                }
                return categoryDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateCategory(CategoryDto categoryDto)
        {
            bool isAdded = false;
            try
            {
                Category category = new Category(){ CategoryName = categoryDto.CategoryName}; 
                var result = _unitOfWork.Categories.Add(category);
                if(result != null)
                {
                    isAdded = true;
                    _unitOfWork.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isAdded;
        }
    }
}
