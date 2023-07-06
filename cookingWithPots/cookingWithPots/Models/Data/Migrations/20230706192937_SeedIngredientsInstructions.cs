using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cookingWithPots.Models.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedIngredientsInstructions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "Content", "RecipeId" },
                values: new object[,]
                {
                    { 1, "1 can Cream of Chicken Soup", 1 },
                    { 2, "1 can peas", 1 },
                    { 3, "1 can carrots", 1 },
                    { 4, "1 package refrigerated buscuits", 1 },
                    { 5, "4 boneless, skinless chicken breasts, chopped into bite size pieces", 1 }
                });

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "InstructionId", "Content", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Place chicken pieces in slow cooker. Pour soup over chicken. Drain peas and carrots, then add those to slow cooker. Cook for 4 hours.", 1 },
                    { 2, "Bake biscuits according to package directions. Spoon chicken and vegetable mixture over biscuits and serve.", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "IngredientId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "InstructionId",
                keyValue: 2);
        }
    }
}
