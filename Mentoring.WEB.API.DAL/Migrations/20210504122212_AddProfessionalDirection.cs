using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentoring.WEB.API.DAL.Migrations
{
    public partial class AddProfessionalDirection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessionalDirections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalDirections", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "ProfessionalDirections",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Програмування" },
                    { 2L, "Медицина" },
                    { 3L, "Педагогіка" },
                    { 4L, "Природничі науки" },
                    { 5L, "Суспільні науки" },
                    { 6L, "Юриспруденція" },
                    { 7L, "Економіка" },
                    { 8L, "Менеджмент" },
                    { 9L, "Маркетинг" },
                    { 10L, "Фінанси" },
                    { 11L, "Журналістика" },
                    { 12L, "Дизайн" },
                    { 13L, "Акторське мистецтво" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalDirectionUserApplication_UserApplicationsId",
                table: "ProfessionalDirectionUserApplication",
                column: "UserApplicationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessionalDirectionUserApplication");

            migrationBuilder.DropTable(
                name: "ProfessionalDirections");
        }
    }
}
