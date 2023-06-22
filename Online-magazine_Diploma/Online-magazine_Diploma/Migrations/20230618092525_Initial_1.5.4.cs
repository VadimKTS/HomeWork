using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_154 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95a5d956-eaac-4eea-bef2-40611aaada76"));

            migrationBuilder.AddColumn<bool>(
                name: "IsEditNeeded",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("66e2b2d0-eb55-44d2-bcad-2ec1dfcb5943"), "admin@mail.com", false, "admin", "AEGcnBWmpVsxPe+HvMvXpoWuPmVbamCGP34GIRXx/ndY1enJBHKjKbD5X319b21ICQ==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("66e2b2d0-eb55-44d2-bcad-2ec1dfcb5943"));

            migrationBuilder.DropColumn(
                name: "IsEditNeeded",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("95a5d956-eaac-4eea-bef2-40611aaada76"), "admin@mail.com", false, "admin", "ABF8fX1vcPj6yfdPIP7XPV7LEVES1x/kDUxgmRNm68zPfbOfbZC7hs3A/buVG7nVXA==", "+ 375 29 000 00 00", 0 });
        }
    }
}
