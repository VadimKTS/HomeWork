using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_151 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6b472fb1-3957-48f6-b9a6-5e5c6280db55"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(85)",
                oldMaxLength: 85);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("39a41dd7-603a-41c4-b8d4-9981de8fa1f2"), "admin@mail.com", false, "admin", "APH9UuLd+1VkQkLuJ9lBIc6oASNkjrp+Mu6BjpKeK5z4LGMYKu8ZEGtGX+l2mmG1Rg==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("39a41dd7-603a-41c4-b8d4-9981de8fa1f2"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Articles",
                type: "nvarchar(85)",
                maxLength: 85,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Articles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("6b472fb1-3957-48f6-b9a6-5e5c6280db55"), "admin@mail.com", false, "admin", "ABmZInMMvC+Wy5+cMs/lCq2pom1TkHj29QOqrjdr5Pd1uO4N5VnEWHJHiFDIsQhbSg==", "+ 375 29 000 00 00", 0 });
        }
    }
}
