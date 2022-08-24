using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestructure.Migrations
{
    public partial class migracionmateria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "estadoid",
                schema: "GET",
                table: "Materia",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "year",
                schema: "GET",
                table: "Materia",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Materia_estadoid",
                schema: "GET",
                table: "Materia",
                column: "estadoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Materia_EstadoMateriaEstudiante_estadoid",
                schema: "GET",
                table: "Materia",
                column: "estadoid",
                principalSchema: "GET",
                principalTable: "EstadoMateriaEstudiante",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materia_EstadoMateriaEstudiante_estadoid",
                schema: "GET",
                table: "Materia");

            migrationBuilder.DropIndex(
                name: "IX_Materia_estadoid",
                schema: "GET",
                table: "Materia");

            migrationBuilder.DropColumn(
                name: "estadoid",
                schema: "GET",
                table: "Materia");

            migrationBuilder.DropColumn(
                name: "year",
                schema: "GET",
                table: "Materia");
        }
    }
}
