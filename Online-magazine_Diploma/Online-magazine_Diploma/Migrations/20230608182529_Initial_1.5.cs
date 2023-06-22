using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1ffad47e-6637-4955-af2a-3a63752742aa"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("6b472fb1-3957-48f6-b9a6-5e5c6280db55"), "admin@mail.com", false, "admin", "ABmZInMMvC+Wy5+cMs/lCq2pom1TkHj29QOqrjdr5Pd1uO4N5VnEWHJHiFDIsQhbSg==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6b472fb1-3957-48f6-b9a6-5e5c6280db55"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("1ffad47e-6637-4955-af2a-3a63752742aa"), "admin@mail.com", false, "admin", "ACza2NyfqxyG/v3p3RzARhWPw3F6XTR5cfF9XEH/FlSwyXXYaRkrCGoSxkRsf3IQaQ==", "+ 375 29 000 00 00", 0 });
        }
    }
}
