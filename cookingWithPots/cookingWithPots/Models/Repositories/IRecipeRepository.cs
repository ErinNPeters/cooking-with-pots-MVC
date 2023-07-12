using cookingWithPots.Models.Data;
using System.Runtime.CompilerServices;

namespace cookingWithPots.Models.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeWithLists(int id);
    }
}
