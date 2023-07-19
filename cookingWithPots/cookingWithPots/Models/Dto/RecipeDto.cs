using cookingWithPots.Models.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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

        [DisplayName("Ingredients")]
        public string IngredientsNotParsed { get; set; }
        [DisplayName("Instructions")]
        public string InstructionsNotParsed { get; set; }

       // [FileExtensions(Extensions ="jpg,jpeg,png,gif,JPG,JPEG,PNG,GIF", ErrorMessage = "Please use an accepted image extension: jpg, jpeg, png, gif.")]
        public IFormFile? ImageFile { get; set; }
        public byte[]? ImageBytes { get; set; }
        public bool DeleteImage { get; set; }

        public Recipe GetRecipeWithLists()
        {
            var recipe = new Recipe
            {
                RecipeId = RecipeId,
                Title = Title,
                Description = Description,
                SlowCooker = SlowCooker,
                Ingredients = new List<Ingredient>(),
                Instructions = new List<Instruction>(),
                DeleteImage = DeleteImage
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

            if(ImageFile != null && ImageFile.Length > 0)
            {
                using (var fileStream = ImageFile.OpenReadStream())
                {
                    byte[] imageBytes = new byte[fileStream.Length];
                    fileStream.Read(imageBytes, 0, imageBytes.Length);
                    recipe.Image = new Image();
                    recipe.Image.ImageData = imageBytes;
                }
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

            if (recipe.Ingredients != null)
            {
                foreach (var ing in recipe.Ingredients)
                {
                    IngredientsNotParsed += ing.Content + Environment.NewLine;
                }
            }
            if (recipe.Instructions != null)
            {
                foreach (var inst in recipe.Instructions)
                {
                    InstructionsNotParsed += inst.Content + Environment.NewLine;
                }
            }
            if(recipe.Image != null && recipe.Image.ImageData.Length > 0)
            {
                ImageBytes = recipe.Image.ImageData;
            }
        }
    }
}
