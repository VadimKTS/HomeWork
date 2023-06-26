using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_magazine_Diploma.Migrations
{
    /// <inheritdoc />
    public partial class Initial_1512 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Titels",
                keyColumn: "Id",
                keyValue: new Guid("08479bca-3dd6-4825-a5f8-88162f1b1e36"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1440b3ce-329d-484c-91fe-f36fd58bf96a"));

            migrationBuilder.InsertData(
                table: "Titels",
                columns: new[] { "Id", "ActivateDate", "ImageAddress", "Name" },
                values: new object[] { new Guid("7840c152-4d64-4232-a258-22883be69eb7"), new DateTime(2023, 6, 26, 16, 1, 23, 948, DateTimeKind.Local).AddTicks(2097), "default", "Default Title Name" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("109d1122-6b75-48a5-b35b-f01ba3ba6dfe"), "admin@mail.com", false, "admin", "AHUatg2IQY5YQvwV8JG2poeDt3y8hu5FNmySjhlTZqZ7vdA/srS6EELXI1QJZUQ3TQ==", "+ 375 29 000 00 00", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Titels",
                keyColumn: "Id",
                keyValue: new Guid("7840c152-4d64-4232-a258-22883be69eb7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("109d1122-6b75-48a5-b35b-f01ba3ba6dfe"));

            migrationBuilder.InsertData(
                table: "Titels",
                columns: new[] { "Id", "ActivateDate", "ImageAddress", "Name" },
                values: new object[] { new Guid("08479bca-3dd6-4825-a5f8-88162f1b1e36"), new DateTime(2023, 6, 20, 0, 5, 55, 949, DateTimeKind.Local).AddTicks(8084), "default", "Default Title Name" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsDeleted", "Name", "PasswordHash", "PhoneNumber", "UserRole" },
                values: new object[] { new Guid("1440b3ce-329d-484c-91fe-f36fd58bf96a"), "admin@mail.com", false, "admin", "AGMlAnBd/HOgdtc5uI4M1mK6wX7KrWyG+s1eChfd9tNa7Kco3V9u4zgrPMACbJ1oJA==", "+ 375 29 000 00 00", 0 });
        }
    }
}
