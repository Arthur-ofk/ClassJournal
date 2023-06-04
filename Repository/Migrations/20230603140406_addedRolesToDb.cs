using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class addedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d9f0c69-f07a-43c1-b8c2-b2e837b77e47", "a4aad9a1-34ec-417c-bc2c-3e0a8eca70b6", "Teacher", null },
                    { "d7694070-8653-424e-b3d9-065aa3ae921d", "539f6c92-903a-4fff-a8fa-60d279afef48", "Student", null },
                    { "f08847ab-1490-424e-bedd-985c6e37aeac", "7b2ec184-3064-4051-a86f-0c9ec9404ba3", "Admin", null }
                });

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("8e68496b-d691-4162-82a9-41cc2a4d89aa"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 17, 4, 6, 173, DateTimeKind.Local).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("aca90b78-fea9-4679-a600-e047765d1c65"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 17, 4, 6, 173, DateTimeKind.Local).AddTicks(1673));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d9f0c69-f07a-43c1-b8c2-b2e837b77e47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7694070-8653-424e-b3d9-065aa3ae921d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08847ab-1490-424e-bedd-985c6e37aeac");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("8e68496b-d691-4162-82a9-41cc2a4d89aa"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 16, 29, 28, 985, DateTimeKind.Local).AddTicks(7754));

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("aca90b78-fea9-4679-a600-e047765d1c65"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 3, 16, 29, 28, 985, DateTimeKind.Local).AddTicks(7715));
        }
    }
}
