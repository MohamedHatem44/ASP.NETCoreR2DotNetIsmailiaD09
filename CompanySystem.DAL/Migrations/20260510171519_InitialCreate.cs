using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanySystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), "SD", null },
                    { 2, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), "UI", null },
                    { 3, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), "Mob", null },
                    { 4, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), "UX", null }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "CreatedAt", "DepartmentId", "Name", "Salary", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 26, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), 1, "Ahmed", 1234m, null },
                    { 2, 36, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), 2, "Mohamed", 2234m, null },
                    { 3, 46, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), 3, "Sara", 4234m, null },
                    { 4, 25, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), 4, "Omar", 5234m, null },
                    { 5, 23, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), 1, "Ali", 6234m, null },
                    { 6, 36, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), 2, "Mai", 7234m, null },
                    { 7, 49, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), 3, "Ramy", 8234m, null },
                    { 8, 18, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), 4, "Hamada", 9234m, null },
                    { 9, 26, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), 1, "Hatem", 10234m, null },
                    { 10, 25, new DateTime(2026, 5, 10, 17, 12, 15, 908, DateTimeKind.Unspecified), 2, "Osama", 17234m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
