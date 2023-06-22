using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_153 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c54d0bcf-1a76-4e5b-9a66-f16a4e79b5fd"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("95a5d956-eaac-4eea-bef2-40611aaada76"), "admin@mail.com", false, "admin", "ABF8fX1vcPj6yfdPIP7XPV7LEVES1x/kDUxgmRNm68zPfbOfbZC7hs3A/buVG7nVXA==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95a5d956-eaac-4eea-bef2-40611aaada76"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("c54d0bcf-1a76-4e5b-9a66-f16a4e79b5fd"), "admin@mail.com", false, "admin", "AHJTIGHckrIOgMnWWnZS+S0LpsZ7KAbjgEFBHAxD0xHnUmbEfGBt3CmtX2YYsPOCig==", "+ 375 29 000 00 00", 0 });
        }
    }
}
