using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_157 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8f97f586-eb0b-4e28-b84d-726067265dc9"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("e12696b1-01f2-401d-9fa1-7575dd0ffbf2"), "admin@mail.com", false, "admin", "ANfxK7/NYQeFe9fspn/37ATT02ys78hIAImcToXxabhmPwLNoTAUIyCVLRsbDoLhXw==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e12696b1-01f2-401d-9fa1-7575dd0ffbf2"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("8f97f586-eb0b-4e28-b84d-726067265dc9"), "admin@mail.com", false, "admin", "ABz4nXLg5PCImmwxwADy9LQagCI4c81L5pysb7QrOaS7yRLthueIKKn+BsuEoNB3/Q==", "+ 375 29 000 00 00", 0 });
        }
    }
}
