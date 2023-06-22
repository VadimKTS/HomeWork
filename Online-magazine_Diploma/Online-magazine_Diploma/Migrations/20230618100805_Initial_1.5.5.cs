using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_155 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("66e2b2d0-eb55-44d2-bcad-2ec1dfcb5943"));

            migrationBuilder.AddColumn<string>(
                name: "AdminDescriptionForEdit",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("07e2d09a-927c-495e-ba3b-f82c1bf47756"), "admin@mail.com", false, "admin", "AAxaY+dPLZk/5O1XRdxzMdaJailj6u4bMSpOu0eDI8FS7T6j6chTPA7+SJfHbQkoDg==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("07e2d09a-927c-495e-ba3b-f82c1bf47756"));

            migrationBuilder.DropColumn(
                name: "AdminDescriptionForEdit",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("66e2b2d0-eb55-44d2-bcad-2ec1dfcb5943"), "admin@mail.com", false, "admin", "AEGcnBWmpVsxPe+HvMvXpoWuPmVbamCGP34GIRXx/ndY1enJBHKjKbD5X319b21ICQ==", "+ 375 29 000 00 00", 0 });
        }
    }
}
