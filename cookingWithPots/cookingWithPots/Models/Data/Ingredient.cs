using System.ComponentModel.DataAnnotations.Schema;

namespace cookingWithPots.Models.Data
{
    [Table("Ingredients")]
    public class Ingredient
    {
        public int IngredientId { get; set; }
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public  string Content { get; set; }

    }
}
