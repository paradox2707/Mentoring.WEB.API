using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentoring.WEB.API.DAL.Migrations
{
    public partial class AddNameAndPhoneNumberForUserApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserApplications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "UserApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "UserApplications",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserApplications");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "UserApplications");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "UserApplications");
        }
    }
}
