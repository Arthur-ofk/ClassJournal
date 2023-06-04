using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClassJournal.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStateLearning",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("8e68496b-d691-4162-82a9-41cc2a4d89aa"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 16, 15, 6, 977, DateTimeKind.Local).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("aca90b78-fea9-4679-a600-e047765d1c65"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 3, 16, 15, 6, 977, DateTimeKind.Local).AddTicks(7077));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("559c7c64-1532-4780-bfc1-083f85ae6e33"),
                columns: new[] { "Adress", "Email", "IsStateLearning", "PhoneNumber" },
                values: new object[] { "Prospekt", "Andre@gmail.com", true, "0680952644" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("9121c45f-aab8-4041-a582-51e3c5454cde"),
                columns: new[] { "Adress", "Email", "IsStateLearning", "PhoneNumber" },
                values: new object[] { "vulytsya pushkina ,dom kolotushkina", "arthauz19@gmail.com", false, "380987432010" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("caa44bf4-b109-4fe8-84cd-dbf87b8906c4"),
                columns: new[] { "Adress", "Email", "IsStateLearning", "PhoneNumber" },
                values: new object[] { "Kobylanska 38", "Bednyy@gmail.com", false, "0684739285" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsStateLearning",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("8e68496b-d691-4162-82a9-41cc2a4d89aa"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 14, 56, 40, 11, DateTimeKind.Local).AddTicks(2035));

            migrationBuilder.UpdateData(
                table: "Marks",
                keyColumn: "Id",
                keyValue: new Guid("aca90b78-fea9-4679-a600-e047765d1c65"),
                column: "CreatedDate",
                value: new DateTime(2023, 2, 1, 14, 56, 40, 11, DateTimeKind.Local).AddTicks(1996));
        }
    }
}
