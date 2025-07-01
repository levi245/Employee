using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeProject.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "employeeSkillId",
                table: "EmployeeSkills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "employeeSkillId",
                table: "EmployeeSkills");
        }
    }
}
