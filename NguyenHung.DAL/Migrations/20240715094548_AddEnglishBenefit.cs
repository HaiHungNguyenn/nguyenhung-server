using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenHung.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddEnglishBenefit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnglishDescription",
                table: "Benefits",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnglishTitle",
                table: "Benefits",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishDescription",
                table: "Benefits");

            migrationBuilder.DropColumn(
                name: "EnglishTitle",
                table: "Benefits");
        }
    }
}
