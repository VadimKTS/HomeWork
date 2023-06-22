using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6cb9f5c4-c53d-419b-b88a-025678001949"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("7c813c1e-f06f-43ca-8d3f-bb9ffb103c44"), "admin@mail.com", false, "admin", "AHt1a9ygKIze+cE4y0CYOkCc9AjeyoaFFyz3qCkDJeRUJafX8gR4H2xMs+Fw8NnKkQ==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7c813c1e-f06f-43ca-8d3f-bb9ffb103c44"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("6cb9f5c4-c53d-419b-b88a-025678001949"), "admin@mail.com", false, "admin", "AA2ovemdHV6dFUcr97ayH1Ws2DvNxBwaY1Pa4nzFnm5obzzmCXMKHgYxX0vlBkm6TQ==", "+ 375 29 000 00 00", 0 });
        }
    }
}
