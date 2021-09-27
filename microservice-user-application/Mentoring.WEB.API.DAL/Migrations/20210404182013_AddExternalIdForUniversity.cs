using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentoring.WEB.API.DAL.Migrations
{
    public partial class AddExternalIdForUniversity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExternalId",
                table: "Universities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Universities");
        }
    }
}
