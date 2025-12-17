using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Multiple_Images.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "url",
                table: "VariantImages",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "VariantImages",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Variants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VariantId",
                table: "VariantImages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Variants_ProductId",
                table: "Variants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VariantImages_VariantId",
                table: "VariantImages",
                column: "VariantId");

            migrationBuilder.AddForeignKey(
                name: "FK_VariantImages_Variants_VariantId",
                table: "VariantImages",
                column: "VariantId",
                principalTable: "Variants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Variants_Products_ProductId",
                table: "Variants",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VariantImages_Variants_VariantId",
                table: "VariantImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Variants_Products_ProductId",
                table: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_Variants_ProductId",
                table: "Variants");

            migrationBuilder.DropIndex(
                name: "IX_VariantImages_VariantId",
                table: "VariantImages");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "VariantId",
                table: "VariantImages");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "VariantImages",
                newName: "url");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VariantImages",
                newName: "id");
        }
    }
}
