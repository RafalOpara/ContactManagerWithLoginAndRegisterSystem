using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomIdentity.Migrations
{
    /// <inheritdoc />
    public partial class updatedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OtherSubcategoryName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SubcategoryId",
                table: "Contacts",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OtherSubcategoryName",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "Contacts");
        }
    }
}
