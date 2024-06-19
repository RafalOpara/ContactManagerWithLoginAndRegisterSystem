using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomIdentity.Migrations
{
    /// <inheritdoc />
    public partial class updatedCOntact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswrodHash",
                table: "Contacts",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Contacts",
                newName: "Password");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Contacts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Contacts",
                newName: "PasswrodHash");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Contacts",
                newName: "FirstName");
        }
    }
}
