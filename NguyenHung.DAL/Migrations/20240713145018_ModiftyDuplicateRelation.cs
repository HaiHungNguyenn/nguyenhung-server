using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenHung.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModiftyDuplicateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutrients_Products_ProductId",
                table: "Nutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_Nutrients_Products_ProductId1",
                table: "Nutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId1",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCookingWears_CookingWears_CookingWearId1",
                table: "RecipeCookingWears");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeCookingWears_Recipes_RecipeId1",
                table: "RecipeCookingWears");

            migrationBuilder.DropIndex(
                name: "IX_RecipeCookingWears_CookingWearId1",
                table: "RecipeCookingWears");

            migrationBuilder.DropIndex(
                name: "IX_RecipeCookingWears_RecipeId1",
                table: "RecipeCookingWears");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId1",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductImages_ProductId1",
                table: "ProductImages");

            migrationBuilder.DropIndex(
                name: "IX_Nutrients_ProductId1",
                table: "Nutrients");

            migrationBuilder.DropColumn(
                name: "CookingWearId1",
                table: "RecipeCookingWears");

            migrationBuilder.DropColumn(
                name: "RecipeId1",
                table: "RecipeCookingWears");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Nutrients");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrients_Products_ProductId",
                table: "Nutrients",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutrients_Products_ProductId",
                table: "Nutrients");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "CookingWearId1",
                table: "RecipeCookingWears",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "RecipeId1",
                table: "RecipeCookingWears",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId1",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "ProductImages",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId1",
                table: "Nutrients",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCookingWears_CookingWearId1",
                table: "RecipeCookingWears",
                column: "CookingWearId1");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeCookingWears_RecipeId1",
                table: "RecipeCookingWears",
                column: "RecipeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId1",
                table: "Products",
                column: "CategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId1",
                table: "ProductImages",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_Nutrients_ProductId1",
                table: "Nutrients",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrients_Products_ProductId",
                table: "Nutrients",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutrients_Products_ProductId1",
                table: "Nutrients",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId",
                table: "ProductImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Products_ProductId1",
                table: "ProductImages",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId1",
                table: "Products",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCookingWears_CookingWears_CookingWearId1",
                table: "RecipeCookingWears",
                column: "CookingWearId1",
                principalTable: "CookingWears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeCookingWears_Recipes_RecipeId1",
                table: "RecipeCookingWears",
                column: "RecipeId1",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
