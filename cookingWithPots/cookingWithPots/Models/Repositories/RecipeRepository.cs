using cookingWithPots.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace cookingWithPots.Models.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        protected ApplicationDbContext _context { get; set; }
        public RecipeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Recipe> GetRecipeWithLists(int id)
        {
            var recipesSet = _context.Recipes;
            var ingredientsSet = _context.Ingredients;
            var InstructionsSet = _context.Instructions;

            var query = from recipes in recipesSet
                        where recipes.RecipeId == id
                        select new Recipe
                        {
                            RecipeId = recipes.RecipeId,
                            Title = recipes.Title,
                            Description = recipes.Description,
                            SlowCooker = recipes.SlowCooker,
                            Ingredients = ingredientsSet.Where(i => i.RecipeId == id).ToList(),
                            Instructions = InstructionsSet.Where(i => i.RecipeId == id).ToList(),
                        };

            return await query.FirstOrDefaultAsync();
        }
    }
}
