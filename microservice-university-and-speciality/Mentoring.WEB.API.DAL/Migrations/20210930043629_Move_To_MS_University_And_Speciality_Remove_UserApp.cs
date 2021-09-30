using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentoring.WEB.API.DAL.Migrations
{
    public partial class Move_To_MS_University_And_Speciality_Remove_UserApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalDirectionUserApplication");

            migrationBuilder.DropTable(
                name: "RegionUserApplication");

            migrationBuilder.DropTable(
                name: "UserApplications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserApplications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AverageMark = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalDirectionUserApplication",
                columns: table => new
                {
                    ProfessionalDirectionsId = table.Column<long>(type: "bigint", nullable: false),
                    UserApplicationsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalDirectionUserApplication", x => new { x.ProfessionalDirectionsId, x.UserApplicationsId });
                    table.ForeignKey(
                        name: "FK_ProfessionalDirectionUserApplication_ProfessionalDirections_ProfessionalDirectionsId",
                        column: x => x.ProfessionalDirectionsId,
                        principalTable: "ProfessionalDirections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessionalDirectionUserApplication_UserApplications_UserApplicationsId",
                        column: x => x.UserApplicationsId,
                        principalTable: "UserApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionUserApplication",
                columns: table => new
                {
                    RegionsId = table.Column<long>(type: "bigint", nullable: false),
                    UserApplicationsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionUserApplication", x => new { x.RegionsId, x.UserApplicationsId });
                    table.ForeignKey(
                        name: "FK_RegionUserApplication_Regions_RegionsId",
                        column: x => x.RegionsId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegionUserApplication_UserApplications_UserApplicationsId",
                        column: x => x.UserApplicationsId,
                        principalTable: "UserApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalDirectionUserApplication_UserApplicationsId",
                table: "ProfessionalDirectionUserApplication",
                column: "UserApplicationsId");

            migrationBuilder.CreateIndex(
                name: "IX_RegionUserApplication_UserApplicationsId",
                table: "RegionUserApplication",
                column: "UserApplicationsId");
        }
    }
}
