using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_Avancerad_.NET.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(nullable: true),
                    LName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeReports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoursWorked = table.Column<double>(nullable: false),
                    WeekNumber = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true),
                    ProjetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeReports_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimeReports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FName", "LName", "Title" },
                values: new object[,]
                {
                    { 1, "Erik", "Norell", "Utvecklare" },
                    { 2, "Viktor", "Gunnarsson", "Utvecklare" },
                    { 3, "Lukas", "Rose", "Utvecklare" },
                    { 4, "Erik", "Risholm", "Utvecklare" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "ProjectName" },
                values: new object[,]
                {
                    { 1, "Lion Bank" },
                    { 2, "Numbers Game" },
                    { 3, "Car Race application" }
                });

            migrationBuilder.InsertData(
                table: "TimeReports",
                columns: new[] { "Id", "EmployeeId", "HoursWorked", "ProjectId", "ProjetId", "WeekNumber" },
                values: new object[,]
                {
                    { 1, 1, 5.0, null, 1, 12 },
                    { 2, 1, 10.0, null, 2, 12 },
                    { 3, 2, 2.0, null, 1, 12 },
                    { 4, 2, 15.0, null, 3, 12 },
                    { 5, 3, 7.0, null, 2, 12 },
                    { 6, 3, 7.0, null, 3, 12 },
                    { 7, 4, 1.0, null, 1, 12 },
                    { 8, 4, 20.0, null, 3, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_EmployeeId",
                table: "TimeReports",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeReports_ProjectId",
                table: "TimeReports",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TimeReports");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}
