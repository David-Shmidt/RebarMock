using Microsoft.EntityFrameworkCore;
using RebarMock.Data;
using RebarMock.Models;
using RebarMock.Repository.RepositoryInterface;

namespace RebarMock.Repository.RepositoryClass
{
    public class IngredientRepository : Repository<Ingredient> , IIngredientsRepository
    {
        public IngredientRepository(DbContext context) : base(context) { }

        protected ApplicationDbContext _appContext{get{return _dbContext as ApplicationDbContext;}}

        public IQueryable<Ingredient> GetFilteredIngredientsById(List<int> ingredientIds)
        {
            var query = _appContext.Ingredients.Where(ingredient => ingredientIds.Contains(ingredient.Id));
            return query;
        }
    }
}
