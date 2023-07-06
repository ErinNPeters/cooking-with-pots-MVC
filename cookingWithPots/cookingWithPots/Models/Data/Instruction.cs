using System.ComponentModel.DataAnnotations.Schema;

namespace cookingWithPots.Models.Data
{
    [Table("Instructions")]
    public class Instruction
    {
        public int InstructionId { get; set; }
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public string Content { get; set; }
    }
}
