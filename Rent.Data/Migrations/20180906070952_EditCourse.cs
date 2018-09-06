using Microsoft.EntityFrameworkCore.Migrations;

namespace Rent.Data.Migrations
{
    public partial class EditCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PeopleCount",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "PeopleNames",
                table: "Courses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PeopleCount",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PeopleNames",
                table: "Courses",
                nullable: true);
        }
    }
}
