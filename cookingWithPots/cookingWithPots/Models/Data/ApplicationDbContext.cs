using cookingWithPots.Models.Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace cookingWithPots.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<Instruction> Instructions => Set<Instruction>();
        public DbSet<Recipe> Recipes => Set<Recipe>();
        public DbSet<Image> Image => Set<Image>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ConfigureRecipes());
            modelBuilder.ApplyConfiguration(new ConfigureIngredients());
            modelBuilder.ApplyConfiguration(new ConfigureInstructions());
        }
    }
}
