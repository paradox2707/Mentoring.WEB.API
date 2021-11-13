using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentoring.WEB.API.DAL.Migrations
{
    public partial class AddRelationshipForSpecialityAndProfessionalDiraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProfessionalDirectionId",
                table: "Specialities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ProfessionalDirectionId",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ProfessionalDirectionId",
                value: 6L);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ProfessionalDirectionId",
                value: 12L);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4L,
                column: "ProfessionalDirectionId",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5L,
                column: "ProfessionalDirectionId",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6L,
                column: "ProfessionalDirectionId",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7L,
                column: "ProfessionalDirectionId",
                value: 9L);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8L,
                column: "ProfessionalDirectionId",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 9L,
                column: "ProfessionalDirectionId",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 10L,
                column: "ProfessionalDirectionId",
                value: 8L);

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_ProfessionalDirectionId",
                table: "Specialities",
                column: "ProfessionalDirectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Specialities_ProfessionalDirections_ProfessionalDirectionId",
                table: "Specialities",
                column: "ProfessionalDirectionId",
                principalTable: "ProfessionalDirections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Specialities_ProfessionalDirections_ProfessionalDirectionId",
                table: "Specialities");

            migrationBuilder.DropIndex(
                name: "IX_Specialities_ProfessionalDirectionId",
                table: "Specialities");

            migrationBuilder.DropColumn(
                name: "ProfessionalDirectionId",
                table: "Specialities");
        }
    }
}
