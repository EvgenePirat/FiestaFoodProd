using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAllStructureBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Orders_OrderId",
                table: "Dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Dishes_DishId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_PaymentInfos_PaymentInfoId",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CustomerInfos_CustomerInfoId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "CustomerInfos");

            migrationBuilder.DropTable(
                name: "PaymentInfos");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerInfoId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderDetailId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_PaymentInfoId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_DishId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_OrderId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "CustomerInfoId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderCardNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderDetailId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderOnTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "DishId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Kilograms",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "PaymentInfoId",
                table: "OrderDetails",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "OrderState",
                table: "OrderDetails",
                newName: "PaymentType");

            migrationBuilder.AddColumn<int>(
                name: "OrderState",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Sum",
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

            migrationBuilder.AddColumn<int>(
                name: "QuantityId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPaths",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateTable(
                name: "DishIngridients",
                columns: table => new
                {
                    DishId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishIngridients", x => new { x.DishId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_DishIngridients_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishIngridients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DishId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.DishId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_QuantityId",
                table: "Ingredients",
                column: "QuantityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DishIngridients_IngredientId",
                table: "DishIngridients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DishId",
                table: "OrderItems",
                column: "DishId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Quantities_QuantityId",
                table: "Ingredients",
                column: "QuantityId",
                principalTable: "Quantities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Quantities_QuantityId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "DishIngridients");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_QuantityId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "OrderState",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Sum",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "QuantityId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "PhotoPaths",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "OrderDetails",
                newName: "OrderState");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderDetails",
                newName: "PaymentInfoId");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerInfoId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<byte>(
                name: "OrderCardNumber",
                table: "Orders",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderDetailId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderOnTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "OrderDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "DishId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Kilograms",
                table: "Ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Dishes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomerInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerInfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PaymentInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    UserPaymentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerInfoId",
                table: "Orders",
                column: "CustomerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderDetailId",
                table: "Orders",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PaymentInfoId",
                table: "OrderDetails",
                column: "PaymentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DishId",
                table: "Ingredients",
                column: "DishId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_OrderId",
                table: "Dishes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInfos_UserId",
                table: "CustomerInfos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Orders_OrderId",
                table: "Dishes",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Dishes_DishId",
                table: "Ingredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_PaymentInfos_PaymentInfoId",
                table: "OrderDetails",
                column: "PaymentInfoId",
                principalTable: "PaymentInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CustomerInfos_CustomerInfoId",
                table: "Orders",
                column: "CustomerInfoId",
                principalTable: "CustomerInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderDetails_OrderDetailId",
                table: "Orders",
                column: "OrderDetailId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
