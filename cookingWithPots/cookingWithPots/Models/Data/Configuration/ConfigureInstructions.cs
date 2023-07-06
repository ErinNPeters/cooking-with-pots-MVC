using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cookingWithPots.Models.Data.Configuration
{
    public class ConfigureInstructions : IEntityTypeConfiguration<Instruction>
    {
        public void Configure(EntityTypeBuilder<Instruction> builder)
        {
            builder.HasData(
                 new { InstructionId = 1, RecipeId = 1, Content = "Place chicken pieces in slow cooker. Pour soup over chicken. Drain peas and carrots, then add those to slow cooker. Cook for 4 hours." },
                 new { InstructionId = 2, RecipeId = 1, Content = "Bake biscuits according to package directions. Spoon chicken and vegetable mixture over biscuits and serve." }
                );
        }
    }
}
