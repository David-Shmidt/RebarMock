using RebarMock.Models;

namespace RebarMock.Repository.RepositoryInterface
{
    public interface IIngredientsRepository : IRepository<Ingredient>
    {
        IQueryable<Ingredient> GetFilteredIngredientsById(List<int> ingredientIds);
    }
}
