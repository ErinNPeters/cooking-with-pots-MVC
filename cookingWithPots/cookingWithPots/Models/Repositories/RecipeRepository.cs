using cookingWithPots.Models.Data;
using cookingWithPots.Models.Dto;
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
            var ImageSet = _context.Image;

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
                            Image = ImageSet.Where(i => i.RecipeId ==id).FirstOrDefault()
                        };

            return await query.FirstOrDefaultAsync();
        }

        public async Task SaveRecipeAll(Recipe recipe)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    //Remove existing Ingredients and Instructions
                    var ingredientsToRemove = _context.Ingredients.Where(r => r.RecipeId == recipe.RecipeId).ToList();
                    _context.RemoveRange(ingredientsToRemove);
                    var instructionsToRemove = _context.Instructions.Where(r => r.RecipeId == recipe.RecipeId).ToList();
                    _context.RemoveRange(instructionsToRemove);

                    if(recipe.Image != null && recipe.Image.ImageData.Length > 0)
                    {
                        var imagesToRemove = _context.Image.Where(r => r.RecipeId == recipe.RecipeId).ToList();
                        _context.RemoveRange(imagesToRemove);
                    }

                    _context.Recipes.Update(recipe);
                    _context.SaveChanges();

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                }
            }

        }

        public async Task<List<Recipe>> GetRecipeAllSearch(RecipeSearchCriteriaDto criteria)
        {
            var recipesSet = _context.Recipes;
            var ingredientsSet = _context.Ingredients;
            var instructionsSet = _context.Instructions;

            var query = from recipes in recipesSet
                        select new Recipe
                        {
                            RecipeId = recipes.RecipeId,
                            Title = recipes.Title,
                            Description = recipes.Description,
                            SlowCooker = recipes.SlowCooker,
                            Ingredients = ingredientsSet.Where(i => i.RecipeId == recipes.RecipeId).ToList(),
                            Instructions = instructionsSet.Where(i => i.RecipeId == recipes.RecipeId).ToList(),
                        };

            if (!string.IsNullOrWhiteSpace(criteria.SearchTerms))
            {
                query = query.Where(entity => entity.Title.ToLower().Contains(criteria.SearchTerms) || entity.Ingredients.Any(i => i.Content.ToLower().Contains(criteria.SearchTerms))
                                                                      || entity.Instructions.Any(s => s.Content.ToLower().Contains(criteria.SearchTerms)));
            }

            if(criteria.SlowCooker.HasValue && criteria.SlowCooker.Value)
            {
                query = query.Where(entity => entity.SlowCooker.HasValue && entity.SlowCooker.Value);
            }

            return await query.ToListAsync();

        }

    }
}
