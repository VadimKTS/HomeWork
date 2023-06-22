using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_156 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07e2d09a-927c-495e-ba3b-f82c1bf47756"));

            migrationBuilder.AddColumn<int>(
                name: "CountOfViews",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("8f97f586-eb0b-4e28-b84d-726067265dc9"), "admin@mail.com", false, "admin", "ABz4nXLg5PCImmwxwADy9LQagCI4c81L5pysb7QrOaS7yRLthueIKKn+BsuEoNB3/Q==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8f97f586-eb0b-4e28-b84d-726067265dc9"));

            migrationBuilder.DropColumn(
                name: "CountOfViews",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("07e2d09a-927c-495e-ba3b-f82c1bf47756"), "admin@mail.com", false, "admin", "AAxaY+dPLZk/5O1XRdxzMdaJailj6u4bMSpOu0eDI8FS7T6j6chTPA7+SJfHbQkoDg==", "+ 375 29 000 00 00", 0 });
        }
    }
}
