using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentoring.WEB.API.DAL.Migrations
{
    public partial class AddToUniversityIsGovermentAndRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsGoverment",
                table: "Universities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RegionId",
                table: "Universities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "IsGoverment", "RegionId" },
                values: new object[] { true, 2L });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "IsGoverment", "RegionId" },
                values: new object[] { true, 2L });

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 3L,
                column: "RegionId",
                value: 6L);

            migrationBuilder.UpdateData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "IsGoverment", "RegionId" },
                values: new object[] { true, 6L });

            migrationBuilder.CreateIndex(
                name: "IX_Universities_RegionId",
                table: "Universities",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Regions_RegionId",
                table: "Universities",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Regions_RegionId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_RegionId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "IsGoverment",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Universities");
        }
    }
}
