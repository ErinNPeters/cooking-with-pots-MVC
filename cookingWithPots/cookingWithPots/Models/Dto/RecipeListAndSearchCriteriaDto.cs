using cookingWithPots.Models.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cookingWithPots.Models.Dto
{
    public class RecipeListAndSearchCriteriaDto
    {
        public RecipeSearchCriteriaDto? searchCriteriaDto { get; set; }
        public List<RecipeDto>? Recipes { get; set; }

        public RecipeListAndSearchCriteriaDto()
        {
            Recipes = new List<RecipeDto>();
        }

        public RecipeListAndSearchCriteriaDto(List<Recipe> recipes)
        {
            Recipes = new List<RecipeDto>();
            foreach (var recipe in recipes)
            {
                Recipes.Add(new RecipeDto(recipe));
            }
        }
    }
}
