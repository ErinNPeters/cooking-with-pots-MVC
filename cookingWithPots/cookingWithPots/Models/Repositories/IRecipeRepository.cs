using cookingWithPots.Models.Data;
using cookingWithPots.Models.Dto;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace cookingWithPots.Models.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeWithLists(int id);
        Task SaveRecipeAll(Recipe recipe);
        Task<List<Recipe>> GetRecipeAllSearch(RecipeSearchCriteriaDto criteria);

    }
}
