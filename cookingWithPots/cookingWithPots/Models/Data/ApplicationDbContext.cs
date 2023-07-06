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
    }
}
