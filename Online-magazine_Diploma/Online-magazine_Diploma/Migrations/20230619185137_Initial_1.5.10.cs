using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1510 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d6732a7-b2e6-4337-8564-93c271a83d52"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Titels",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivateDate",
                table: "Titels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("f4b911b1-d3ea-4b85-b79c-14de1e868010"), "admin@mail.com", false, "admin", "ABGCYepc/qPunvIJ7shh5Eyz2YwHt+Z9hUMbk8uH+8nt2VuNsNztSHYFZWxr+WSRoQ==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f4b911b1-d3ea-4b85-b79c-14de1e868010"));

            migrationBuilder.DropColumn(
                name: "ActivateDate",
                table: "Titels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Titels",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(80)",
                oldMaxLength: 80);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("6d6732a7-b2e6-4337-8564-93c271a83d52"), "admin@mail.com", false, "admin", "AECXzjVmbSPK+kMdLxQDCdSYqKI6gZyMrVXbIhpCMx5iQfup3YKNSvO0xl5GrbVY7Q==", "+ 375 29 000 00 00", 0 });
        }
    }
}
