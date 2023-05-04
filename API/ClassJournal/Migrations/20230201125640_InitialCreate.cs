using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClassJournal.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    GroupCourse = table.Column<int>(type: "int", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MarkValue = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StudentAge = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "GroupCourse", "GroupName" },
                values: new object[,]
                {
                    { new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb"), 4, "144b" },
                    { new Guid("5e5d5c0e-1b88-45e4-96c4-059f2db0de95"), 1, "143b" }
                });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "CreatedDate", "MarkValue", "StudentId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("8e68496b-d691-4162-82a9-41cc2a4d89aa"), new DateTime(2023, 2, 1, 14, 56, 40, 11, DateTimeKind.Local).AddTicks(2035), 90, new Guid("caa44bf4-b109-4fe8-84cd-dbf87b8906c4"), new Guid("21dc68ab-72e4-41c0-b27f-9e3631c3da88") },
                    { new Guid("aca90b78-fea9-4679-a600-e047765d1c65"), new DateTime(2023, 2, 1, 14, 56, 40, 11, DateTimeKind.Local).AddTicks(1996), 80, new Guid("9121c45f-aab8-4041-a582-51e3c5454cde"), new Guid("22ec677b-2a66-4cc0-8590-0ae600f587cc") }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "SubjectName" },
                values: new object[,]
                {
                    { new Guid("21dc68ab-72e4-41c0-b27f-9e3631c3da88"), "Programming" },
                    { new Guid("22ec677b-2a66-4cc0-8590-0ae600f587cc"), "Math" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "GroupId", "Role", "StudentAge", "StudentName" },
                values: new object[,]
                {
                    { new Guid("559c7c64-1532-4780-bfc1-083f85ae6e33"), new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb"), "Student", 22, "Andrew" },
                    { new Guid("9121c45f-aab8-4041-a582-51e3c5454cde"), new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb"), "leader", 19, "Artur" },
                    { new Guid("caa44bf4-b109-4fe8-84cd-dbf87b8906c4"), new Guid("339cc24f-5d1e-48e3-a0a2-f03baa93c2eb"), "Student", 18, "Nazar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
