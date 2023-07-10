using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1513 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Titels",
                keyColumn: "Id",
                keyValue: new Guid("7840c152-4d64-4232-a258-22883be69eb7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("109d1122-6b75-48a5-b35b-f01ba3ba6dfe"));

            migrationBuilder.AddColumn<DateTime>(
                name: "VipStatusEnd",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Titels",
                columns: new[] { "Id", "ActivateDate", "ImageAddress", "Name" },
                values: new object[] { new Guid("842f58a0-b3e8-4aac-a8e3-1394e4bd3501"), new DateTime(2023, 7, 10, 11, 56, 5, 210, DateTimeKind.Local).AddTicks(3282), "default", "Default Title Name" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole", "VipStatusEnd" },
                values: new object[] { new Guid("90d15dc8-498b-493f-9ece-b2d8a567be98"), "admin@mail.com", false, "admin", "AL6yig2KhQsyypQo+k3NA+5mRKX2DsPavtDwQWH6pmyNgejYT5ANUcfJnPXC9nrOFg==", "+ 375 29 000 00 00", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Titels",
                keyColumn: "Id",
                keyValue: new Guid("842f58a0-b3e8-4aac-a8e3-1394e4bd3501"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("90d15dc8-498b-493f-9ece-b2d8a567be98"));

            migrationBuilder.DropColumn(
                name: "VipStatusEnd",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Titels",
                columns: new[] { "Id", "ActivateDate", "ImageAddress", "Name" },
                values: new object[] { new Guid("7840c152-4d64-4232-a258-22883be69eb7"), new DateTime(2023, 6, 26, 16, 1, 23, 948, DateTimeKind.Local).AddTicks(2097), "default", "Default Title Name" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("109d1122-6b75-48a5-b35b-f01ba3ba6dfe"), "admin@mail.com", false, "admin", "AHUatg2IQY5YQvwV8JG2poeDt3y8hu5FNmySjhlTZqZ7vdA/srS6EELXI1QJZUQ3TQ==", "+ 375 29 000 00 00", 0 });
        }
    }
}
