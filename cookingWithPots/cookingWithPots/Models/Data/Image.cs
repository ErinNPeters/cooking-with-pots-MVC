using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cookingWithPots.Models.Data
{
    [Table("Images")]
    public class Image
    {
        [Key]
        public int ImageId { get; set; }
        [ForeignKey(nameof(Recipe))]
        public int RecipeId { get; set; }
        public byte[] ImageData { get; set; }

        [ForeignKey("RecipeId")]
        [InverseProperty("Image")]
        public virtual Recipe Recipe { get; set; } = null!;
    }
}
