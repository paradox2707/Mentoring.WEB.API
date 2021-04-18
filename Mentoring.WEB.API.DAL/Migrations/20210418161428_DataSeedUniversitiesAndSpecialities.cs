using Microsoft.EntityFrameworkCore.Migrations;

namespace Mentoring.WEB.API.DAL.Migrations
{
    public partial class DataSeedUniversitiesAndSpecialities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "ExternalId", "Name" },
                values: new object[,]
                {
                    { 1L, null, "Національна безпека" },
                    { 2L, null, "Право" },
                    { 3L, null, "дизайн" },
                    { 4L, null, "Соціологія" },
                    { 5L, null, "Фінанси, банківська справа та страхування" },
                    { 6L, null, "Менеджмент" },
                    { 7L, null, "Маркетинг" },
                    { 8L, null, "фінанси і кредит" },
                    { 9L, null, "менеджмент організацій і адміністрування" },
                    { 10L, null, "менеджмент зовнішньоекономічної діяльності" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "ExternalId", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1L, null, "Академія зовнішньої розвідки України", "AЗРУ" },
                    { 2L, null, "Академія праці, соціальних відносин і туризму", "АПСВТ" },
                    { 4L, null, "Вищий навчальний заклад \"Київська Академія перукарського мистецтва\"", "ВНЗ \"КАПМ\"" },
                    { 5L, null, "Вищий навчальний заклад \"Київський економічний інститут менеджменту\" у формі Товариства з обмеженою відповідальністю", "КЕІМ" }
                });

            migrationBuilder.InsertData(
                table: "SpecialityUniversity",
                columns: new[] { "SpecialitiesId", "UniversitiesId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 2L },
                    { 3L, 2L },
                    { 6L, 2L },
                    { 5L, 4L },
                    { 6L, 4L },
                    { 7L, 4L },
                    { 8L, 4L },
                    { 9L, 4L },
                    { 10L, 4L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "SpecialityUniversity",
                keyColumns: new[] { "SpecialitiesId", "UniversitiesId" },
                keyValues: new object[] { 1L, 1L });

            migrationBuilder.DeleteData(
                table: "SpecialityUniversity",
                keyColumns: new[] { "SpecialitiesId", "UniversitiesId" },
                keyValues: new object[] { 2L, 2L });

            migrationBuilder.DeleteData(
                table: "SpecialityUniversity",
                keyColumns: new[] { "SpecialitiesId", "UniversitiesId" },
                keyValues: new object[] { 3L, 2L });

            migrationBuilder.DeleteData(
                table: "SpecialityUniversity",
                keyColumns: new[] { "SpecialitiesId", "UniversitiesId" },
                keyValues: new object[] { 5L, 4L });

            migrationBuilder.DeleteData(
                table: "SpecialityUniversity",
                keyColumns: new[] { "SpecialitiesId", "UniversitiesId" },
                keyValues: new object[] { 6L, 2L });

            migrationBuilder.DeleteData(
                table: "SpecialityUniversity",
                keyColumns: new[] { "SpecialitiesId", "UniversitiesId" },
                keyValues: new object[] { 6L, 4L });

            migrationBuilder.DeleteData(
                table: "SpecialityUniversity",
                keyColumns: new[] { "SpecialitiesId", "UniversitiesId" },
                keyValues: new object[] { 7L, 4L });

            migrationBuilder.DeleteData(
                table: "SpecialityUniversity",
                keyColumns: new[] { "SpecialitiesId", "UniversitiesId" },
                keyValues: new object[] { 8L, 4L });

            migrationBuilder.DeleteData(
                table: "SpecialityUniversity",
                keyColumns: new[] { "SpecialitiesId", "UniversitiesId" },
                keyValues: new object[] { 9L, 4L });

            migrationBuilder.DeleteData(
                table: "SpecialityUniversity",
                keyColumns: new[] { "SpecialitiesId", "UniversitiesId" },
                keyValues: new object[] { 10L, 4L });

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Universities",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
