using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DeleteData(
                table: "Titels",
                keyColumn: "Id",
                keyValue: new Guid("842f58a0-b3e8-4aac-a8e3-1394e4bd3501"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90d15dc8-498b-493f-9ece-b2d8a567be98"));

            migrationBuilder.InsertData(
                table: "Titels",
                columns: new[] { "Id", "ActivateDate", "ImageAddress", "Name" },
                values: new object[] { new Guid("e67e6a7e-5ccb-488d-a7a4-1aa876efe784"), new DateTime(2023, 7, 18, 2, 5, 31, 928, DateTimeKind.Local).AddTicks(7791), "default", "Default Title Name" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole", "VipStatusEnd" },
                values: new object[] { new Guid("21c8053d-8cf1-484b-8559-c3de0dd037ef"), "admin@mail.com", false, "admin", "AFP+WW9x5Utu7JHOJTWDx1fHPJ+z3tMWuEsoXDio/2kovv9tRsw/aUCWvfc57C4TYQ==", "+ 375 29 000 00 00", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Titels",
                keyColumn: "Id",
                keyValue: new Guid("e67e6a7e-5ccb-488d-a7a4-1aa876efe784"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("21c8053d-8cf1-484b-8559-c3de0dd037ef"));

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Titels",
                columns: new[] { "Id", "ActivateDate", "ImageAddress", "Name" },
                values: new object[] { new Guid("842f58a0-b3e8-4aac-a8e3-1394e4bd3501"), new DateTime(2023, 7, 10, 11, 56, 5, 210, DateTimeKind.Local).AddTicks(3282), "default", "Default Title Name" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole", "VipStatusEnd" },
                values: new object[] { new Guid("90d15dc8-498b-493f-9ece-b2d8a567be98"), "admin@mail.com", false, "admin", "AL6yig2KhQsyypQo+k3NA+5mRKX2DsPavtDwQWH6pmyNgejYT5ANUcfJnPXC9nrOFg==", "+ 375 29 000 00 00", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ArticleId",
                table: "Ratings",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }
    }
}
