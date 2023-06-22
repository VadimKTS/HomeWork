using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7c813c1e-f06f-43ca-8d3f-bb9ffb103c44"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ArticleTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("1ffad47e-6637-4955-af2a-3a63752742aa"), "admin@mail.com", false, "admin", "ACza2NyfqxyG/v3p3RzARhWPw3F6XTR5cfF9XEH/FlSwyXXYaRkrCGoSxkRsf3IQaQ==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1ffad47e-6637-4955-af2a-3a63752742aa"));

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ArticleTypes");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("7c813c1e-f06f-43ca-8d3f-bb9ffb103c44"), "admin@mail.com", false, "admin", "AHt1a9ygKIze+cE4y0CYOkCc9AjeyoaFFyz3qCkDJeRUJafX8gR4H2xMs+Fw8NnKkQ==", "+ 375 29 000 00 00", 0 });
        }
    }
}
