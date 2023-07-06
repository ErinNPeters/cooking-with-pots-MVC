using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cookingWithPots.Models.Data.Configuration
{
    public class ConfigureRecipes : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasData( 
                new { RecipeId = 1, Title = "Chicken a la King", Description = "Chicken in a savory cream sauce with vegtables", SlowCooker = true}
                );
        }
    }
}
