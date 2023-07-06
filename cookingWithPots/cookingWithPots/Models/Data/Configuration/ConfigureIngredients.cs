using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cookingWithPots.Models.Data.Configuration
{
    public class ConfigureIngredients : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasData(
               new { IngredientId = 1, RecipeId = 1, Content = "1 can Cream of Chicken Soup" },
                new { IngredientId = 2, RecipeId = 1, Content = "1 can peas" },
                new { IngredientId = 3, RecipeId = 1, Content = "1 can carrots" },
                new { IngredientId = 4, RecipeId = 1, Content = "1 package refrigerated buscuits" },
                new { IngredientId = 5, RecipeId = 1, Content = "4 boneless, skinless chicken breasts, chopped into bite size pieces" }
                );
        }
    }
}
