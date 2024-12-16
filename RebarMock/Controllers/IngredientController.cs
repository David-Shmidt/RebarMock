using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RebarMock.Data;
using RebarMock.Models.Dtos;
using RebarMock.Services;

namespace RebarMock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        private IngredientService _ingredientService;
        public IngredientController(IUnitOfWork unitOfWork)
        {
            _ingredientService = new IngredientService(unitOfWork);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<IngredientDto>>> GetAllIngredients()
        {
            try
            {
                ICollection<IngredientDto> ingredients = await _ingredientService.GetAllIngredients();
                if(!ingredients.IsNullOrEmpty())
                {
                    return Ok(ingredients);
                }
                else
                {
                    return NotFound("Could not retrieve ingredients");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<IngredientDto> CreateIngredient([FromBody] IngredientDto ingredient)
        {
            try
            {
                bool isCreated = _ingredientService.CreateIngredient(ingredient);
                if(isCreated)
                {
                    return Ok(ingredient);
                }
                else
                {
                    return BadRequest("Could not create");
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
