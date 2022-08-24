using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantesXMateria_EstadoMateriaEstudiante_estadoid",
                schema: "GET",
                table: "EstudiantesXMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantesXMateria_Estudiante_estudianteid",
                schema: "GET",
                table: "EstudiantesXMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantesXMateria_Materia_materiaid",
                schema: "GET",
                table: "EstudiantesXMateria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstudiantesXMateria",
                schema: "GET",
                table: "EstudiantesXMateria");

            migrationBuilder.RenameTable(
                name: "EstudiantesXMateria",
                schema: "GET",
                newName: "EstudiantesMateria",
                newSchema: "GET");

            migrationBuilder.RenameIndex(
                name: "IX_EstudiantesXMateria_materiaid",
                schema: "GET",
                table: "EstudiantesMateria",
                newName: "IX_EstudiantesMateria_materiaid");

            migrationBuilder.RenameIndex(
                name: "IX_EstudiantesXMateria_estudianteid",
                schema: "GET",
                table: "EstudiantesMateria",
                newName: "IX_EstudiantesMateria_estudianteid");

            migrationBuilder.RenameIndex(
                name: "IX_EstudiantesXMateria_estadoid",
                schema: "GET",
                table: "EstudiantesMateria",
                newName: "IX_EstudiantesMateria_estadoid");

            migrationBuilder.AddColumn<float>(
                name: "resultado",
                schema: "GET",
                table: "EstudiantesMateria",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstudiantesMateria",
                schema: "GET",
                table: "EstudiantesMateria",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantesMateria_EstadoMateriaEstudiante_estadoid",
                schema: "GET",
                table: "EstudiantesMateria",
                column: "estadoid",
                principalSchema: "GET",
                principalTable: "EstadoMateriaEstudiante",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantesMateria_Estudiante_estudianteid",
                schema: "GET",
                table: "EstudiantesMateria",
                column: "estudianteid",
                principalSchema: "GET",
                principalTable: "Estudiante",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantesMateria_Materia_materiaid",
                schema: "GET",
                table: "EstudiantesMateria",
                column: "materiaid",
                principalSchema: "GET",
                principalTable: "Materia",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantesMateria_EstadoMateriaEstudiante_estadoid",
                schema: "GET",
                table: "EstudiantesMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantesMateria_Estudiante_estudianteid",
                schema: "GET",
                table: "EstudiantesMateria");

            migrationBuilder.DropForeignKey(
                name: "FK_EstudiantesMateria_Materia_materiaid",
                schema: "GET",
                table: "EstudiantesMateria");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EstudiantesMateria",
                schema: "GET",
                table: "EstudiantesMateria");

            migrationBuilder.DropColumn(
                name: "resultado",
                schema: "GET",
                table: "EstudiantesMateria");

            migrationBuilder.RenameTable(
                name: "EstudiantesMateria",
                schema: "GET",
                newName: "EstudiantesXMateria",
                newSchema: "GET");

            migrationBuilder.RenameIndex(
                name: "IX_EstudiantesMateria_materiaid",
                schema: "GET",
                table: "EstudiantesXMateria",
                newName: "IX_EstudiantesXMateria_materiaid");

            migrationBuilder.RenameIndex(
                name: "IX_EstudiantesMateria_estudianteid",
                schema: "GET",
                table: "EstudiantesXMateria",
                newName: "IX_EstudiantesXMateria_estudianteid");

            migrationBuilder.RenameIndex(
                name: "IX_EstudiantesMateria_estadoid",
                schema: "GET",
                table: "EstudiantesXMateria",
                newName: "IX_EstudiantesXMateria_estadoid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EstudiantesXMateria",
                schema: "GET",
                table: "EstudiantesXMateria",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantesXMateria_EstadoMateriaEstudiante_estadoid",
                schema: "GET",
                table: "EstudiantesXMateria",
                column: "estadoid",
                principalSchema: "GET",
                principalTable: "EstadoMateriaEstudiante",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantesXMateria_Estudiante_estudianteid",
                schema: "GET",
                table: "EstudiantesXMateria",
                column: "estudianteid",
                principalSchema: "GET",
                principalTable: "Estudiante",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EstudiantesXMateria_Materia_materiaid",
                schema: "GET",
                table: "EstudiantesXMateria",
                column: "materiaid",
                principalSchema: "GET",
                principalTable: "Materia",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
