using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestExamen.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TheoryScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PracticalScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PresentationScore = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalGrade = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "StudentName" },
                values: new object[,]
                {
                    { 1, "Van Damme, Lisa" },
                    { 2, "Janssens, Thomas" },
                    { 3, "Peeters, Emma" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "PracticalScore", "PresentationScore", "StudentId", "SubmissionDate", "TheoryScore", "TotalGrade" },
                values: new object[,]
                {
                    { 1, 14.0m, 3.8m, 1, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 16.5m, 34.3m },
                    { 2, 16.5m, 4.5m, 2, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 18m, 39m },
                    { 3, 13.0m, 3.2m, 3, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 14.5m, 4.0m },
                    { 4, 15.5m, 4.0m, 2, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 17.0m, 36.5m },
                    { 5, 17.5m, 4.8m, 1, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 19.0m, 41.3m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_StudentId",
                table: "Projects",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
