using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multiple_Images.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "displayOrder",
                table: "VariantImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "displayOrder",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "displayOrder",
                table: "VariantImages");

            migrationBuilder.DropColumn(
                name: "displayOrder",
                table: "Images");
        }
    }
}
