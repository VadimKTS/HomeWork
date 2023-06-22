using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("897bddbb-4f8f-4242-b8d0-dc4ffcd7a38c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("cc05e83a-6721-448d-b15f-5442f426d7dd"), "admin@mail.com", false, "admin", "AOlenssFN2QToJSa+ai4hpSA7CgvVGYTGNWSnSTgBEjPHWCPE2WdK5Itb+QutF1dzw==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cc05e83a-6721-448d-b15f-5442f426d7dd"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("897bddbb-4f8f-4242-b8d0-dc4ffcd7a38c"), "admin@mail.com", false, "admin", "admin", "+ 375 29 000 00 00", 0 });
        }
    }
}
