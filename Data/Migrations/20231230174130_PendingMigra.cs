using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Issue_tracker_webapp.Data.Migrations
{
    public partial class PendingMigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_issues_projects_projectID1",
                table: "issues");

            migrationBuilder.DropColumn(
                name: "projectID",
                table: "issues");

            migrationBuilder.AlterColumn<Guid>(
                name: "projectID1",
                table: "issues",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_issues_projects_projectID1",
                table: "issues",
                column: "projectID1",
                principalTable: "projects",
                principalColumn: "projectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_issues_projects_projectID1",
                table: "issues");

            migrationBuilder.AlterColumn<Guid>(
                name: "projectID1",
                table: "issues",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "projectID",
                table: "issues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_issues_projects_projectID1",
                table: "issues",
                column: "projectID1",
                principalTable: "projects",
                principalColumn: "projectID");
        }
    }
}
