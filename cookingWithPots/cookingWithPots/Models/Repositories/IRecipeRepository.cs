using cookingWithPots.Models.Data;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace cookingWithPots.Models.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeWithLists(int id);
        Task SaveRecipeAll(Recipe recipe);
    }
}
