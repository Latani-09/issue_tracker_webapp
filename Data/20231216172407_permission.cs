using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_tracker_webapp.data
{
    public partial class permission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "projectID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    projectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    projectDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.projectID);
                });

            migrationBuilder.CreateTable(
                name: "issues",
                columns: table => new
                {
                    issueID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectID = table.Column<int>(type: "int", nullable: false),
                    issueTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    issueDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    assigneeID = table.Column<int>(type: "int", nullable: false),
                    reporterID = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_issues", x => x.issueID);
                    table.ForeignKey(
                        name: "FK_issues_projects_projectID",
                        column: x => x.projectID,
                        principalTable: "projects",
                        principalColumn: "projectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_projectID",
                table: "AspNetUsers",
                column: "projectID");

            migrationBuilder.CreateIndex(
                name: "IX_issues_projectID",
                table: "issues",
                column: "projectID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_projects_projectID",
                table: "AspNetUsers",
                column: "projectID",
                principalTable: "projects",
                principalColumn: "projectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_projects_projectID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "issues");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_projectID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "projectID",
                table: "AspNetUsers");
        }
    }
}
