using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cookingWithPots.Models.Data
{
    [Table("Recipes")]
    [Index(nameof(Title))]
    public class Recipe
    {
        [Key]
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? SlowCooker { get; set; }

        public ICollection<Ingredient> Ingredients { get; set;}
        public ICollection<Instruction> Instructions { get; set;}

        [NotMapped]
        public string IngredientsNotParsed { get; set; }
        [NotMapped]
        public string InstructionsNotParsed { get; set; }
    }
}
