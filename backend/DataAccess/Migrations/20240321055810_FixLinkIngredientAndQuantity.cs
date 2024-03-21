using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixLinkIngredientAndQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Quantities_QuantityId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_QuantityId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "QuantityId",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Quantities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Quantities_IngredientId",
                table: "Quantities",
                column: "IngredientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Quantities_Ingredients_IngredientId",
                table: "Quantities",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quantities_Ingredients_IngredientId",
                table: "Quantities");

            migrationBuilder.DropIndex(
                name: "IX_Quantities_IngredientId",
                table: "Quantities");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Quantities");

            migrationBuilder.AddColumn<int>(
                name: "QuantityId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_QuantityId",
                table: "Ingredients",
                column: "QuantityId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Quantities_QuantityId",
                table: "Ingredients",
                column: "QuantityId",
                principalTable: "Quantities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
