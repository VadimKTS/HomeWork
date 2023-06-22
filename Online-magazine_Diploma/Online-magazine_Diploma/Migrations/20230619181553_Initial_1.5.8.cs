using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_158 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e12696b1-01f2-401d-9fa1-7575dd0ffbf2"));

            migrationBuilder.AddColumn<Guid>(
                name: "TitelId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TitelId1",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Titels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("1b5ea0ba-3837-4b6c-9080-6ffc64f03967"), "admin@mail.com", false, "admin", "ADVwl8yppxZ61ME+gV22Csp/rg2OSA+aqxKJacbRRsIHXaEvtxe/pYizaFO3YDpufQ==", "+ 375 29 000 00 00", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TitelId",
                table: "Articles",
                column: "TitelId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TitelId1",
                table: "Articles",
                column: "TitelId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Titels_TitelId",
                table: "Articles",
                column: "TitelId",
                principalTable: "Titels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Titels_TitelId1",
                table: "Articles",
                column: "TitelId1",
                principalTable: "Titels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Titels_TitelId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Titels_TitelId1",
                table: "Articles");

            migrationBuilder.DropTable(
                name: "Titels");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TitelId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TitelId1",
                table: "Articles");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1b5ea0ba-3837-4b6c-9080-6ffc64f03967"));

            migrationBuilder.DropColumn(
                name: "TitelId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "TitelId1",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("e12696b1-01f2-401d-9fa1-7575dd0ffbf2"), "admin@mail.com", false, "admin", "ANfxK7/NYQeFe9fspn/37ATT02ys78hIAImcToXxabhmPwLNoTAUIyCVLRsbDoLhXw==", "+ 375 29 000 00 00", 0 });
        }
    }
}
