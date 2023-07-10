using cookingWithPots.Models.Data;

namespace cookingWithPots.Models.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeWithLists(int id);
    }
}
