using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenHung.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSizeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SizeType",
                table: "Products",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SizeType",
                table: "Products");
        }
    }
}
