using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryValue",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Ingredients",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "PhotoPaths",
                table: "Dishes",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Dishes",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "PhotoPaths",
                table: "Categories",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Image");

            migrationBuilder.AddColumn<double>(
                name: "MinCount",
                table: "Quantities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinCount",
                table: "Quantities");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Ingredients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Dishes",
                newName: "PhotoPaths");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Dishes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Categories",
                newName: "PhotoPaths");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.AddColumn<double>(
                name: "EntryValue",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Importance",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
