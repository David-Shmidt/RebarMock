using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RebarMock.Data;
using RebarMock.Models.Dtos;
using RebarMock.Services;

namespace RebarMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategoryService _categoryService;
        public CategoryController(IUnitOfWork unitOfWork) {_categoryService = new CategoryService(unitOfWork);}

        [HttpGet]
        public async Task<ActionResult<ICollection<CategoryDto>>> GetAllCategories()
        {
            try
            {
                ICollection<CategoryDto> Categories = await _categoryService.GetAllCategories();
                return Ok(Categories);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public bool CreateCategory(CategoryDto categoryDto)
        {
            return _categoryService.CreateCategory(categoryDto);
        }
    }
}
