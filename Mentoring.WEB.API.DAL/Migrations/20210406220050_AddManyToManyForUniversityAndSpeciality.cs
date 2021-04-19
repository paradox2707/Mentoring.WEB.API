using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentoring.WEB.API.DAL.Migrations
{
    public partial class AddManyToManyForUniversityAndSpeciality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpecialityUniversity",
                columns: table => new
                {
                    SpecialitiesId = table.Column<long>(type: "bigint", nullable: false),
                    UniversitiesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialityUniversity", x => new { x.SpecialitiesId, x.UniversitiesId });
                    table.ForeignKey(
                        name: "FK_SpecialityUniversity_Specialities_SpecialitiesId",
                        column: x => x.SpecialitiesId,
                        principalTable: "Specialities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialityUniversity_Universities_UniversitiesId",
                        column: x => x.UniversitiesId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialityUniversity_UniversitiesId",
                table: "SpecialityUniversity",
                column: "UniversitiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecialityUniversity");
        }
    }
}
