using Microsoft.IdentityModel.Tokens;
using RebarMock.Data;
using RebarMock.Models;
using RebarMock.Models.Dtos;
using RebarMock.Utils;
using System.Diagnostics;

namespace RebarMock.Services
{
    public class IngredientService
    {
        private IUnitOfWork _unitOfWork;
        public IngredientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<IngredientDto>> GetAllIngredients()
        {
            try
            {
                ICollection<Ingredient> ingredients = await _unitOfWork.Ingredients.GetAll();
                ICollection<IngredientDto> ingredientDtos = new List<IngredientDto>(); 
                if(!ingredients.IsNullOrEmpty())
                {
                    foreach(var item in  ingredients)
                    {
                        ingredientDtos.Add(IngredientConvertor.ConvertToDto(item));
                    }
                }
                return ingredientDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateIngredient(IngredientDto ingredientDto)
        {
            try
            {
                bool isCreated = false;
                Ingredient ingredient =  _unitOfWork.Ingredients.Add(IngredientConvertor.ConvertToModel(ingredientDto));
                if(ingredient != null)
                {
                    isCreated = true;
                    _unitOfWork.SaveChanges();
                }

                return isCreated;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
