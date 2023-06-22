using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_159 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Titels_TitelId1",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TitelId1",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1b5ea0ba-3837-4b6c-9080-6ffc64f03967"));

            migrationBuilder.DropColumn(
                name: "TitelId1",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("6d6732a7-b2e6-4337-8564-93c271a83d52"), "admin@mail.com", false, "admin", "AECXzjVmbSPK+kMdLxQDCdSYqKI6gZyMrVXbIhpCMx5iQfup3YKNSvO0xl5GrbVY7Q==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6d6732a7-b2e6-4337-8564-93c271a83d52"));

            migrationBuilder.AddColumn<Guid>(
                name: "TitelId1",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("1b5ea0ba-3837-4b6c-9080-6ffc64f03967"), "admin@mail.com", false, "admin", "ADVwl8yppxZ61ME+gV22Csp/rg2OSA+aqxKJacbRRsIHXaEvtxe/pYizaFO3YDpufQ==", "+ 375 29 000 00 00", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TitelId1",
                table: "Articles",
                column: "TitelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Titels_TitelId1",
                table: "Articles",
                column: "TitelId1",
                principalTable: "Titels",
                principalColumn: "Id");
        }
    }
}
