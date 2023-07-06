using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cookingWithPots.Models.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "RecipeId", "Description", "SlowCooker", "Title" },
                values: new object[] { 1, "Chicken in a savory cream sauce with vegtables", true, "Chicken a la King" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "RecipeId",
                keyValue: 1);
        }
    }
}
