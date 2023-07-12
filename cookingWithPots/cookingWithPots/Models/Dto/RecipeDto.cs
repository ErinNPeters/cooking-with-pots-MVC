using cookingWithPots.Models.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cookingWithPots.Models.Dto
{
    public class RecipeDto
    {
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? SlowCooker { get; set; }

        public string IngredientsNotParsed { get; set; }
        public string InstructionsNotParsed { get; set; }

        public Recipe GetRecipeWithLists()
        {
            var recipe = new Recipe
            {
                RecipeId = RecipeId,
                Title = Title,
                Description = Description,
                SlowCooker = SlowCooker,
                Ingredients = new List<Ingredient>(),
                Instructions = new List<Instruction>()
            };

            var ingredientsList = IngredientsNotParsed.Split(new string[] { Environment.NewLine, "\\n", "/n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var ingredient in ingredientsList)
            {
                recipe.Ingredients.Add(new Ingredient { Content = ingredient });
            }
            var stepList = InstructionsNotParsed.Split(new string[] { Environment.NewLine, "\\n", "/n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var step in stepList)
            {
                recipe.Instructions.Add(new Instruction { Content = step });
            }
            return recipe;
        }

        public RecipeDto() { }

        public RecipeDto(Recipe recipe)
        {
            RecipeId = recipe.RecipeId;
            Title = recipe.Title;
            Description = recipe.Description;
            SlowCooker = recipe.SlowCooker;

            foreach (var ing in recipe.Ingredients)
            {
                IngredientsNotParsed += ing.Content + Environment.NewLine;
            }
            foreach (var inst in recipe.Instructions)
            {
                InstructionsNotParsed += inst.Content + Environment.NewLine;
            }
        }
    }
}
