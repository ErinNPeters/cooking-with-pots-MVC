using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cookingWithPots.Models.Data
{
    [Table("Ingredients")]
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public  string Content { get; set; }

        [ForeignKey("RecipeId")]
        [InverseProperty("Ingredients")]
        public virtual Recipe Recipe { get; set; } = null!;

    }
}
