using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudiantesInfraestructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GET");

            migrationBuilder.CreateTable(
                name: "EstadoEstudiante",
                schema: "GET",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoEstudiante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoMateriaEstudiante",
                schema: "GET",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoMateriaEstudiante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoProfesor",
                schema: "GET",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoProfesor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                schema: "GET",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    codigo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDocumento",
                schema: "GET",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    codigo = table.Column<string>(nullable: true),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                schema: "GET",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    documento = table.Column<string>(nullable: true),
                    TipoDocumentoid = table.Column<int>(nullable: true),
                    fechaNacimiento = table.Column<DateTime>(nullable: false),
                    sexo = table.Column<string>(nullable: true),
                    direccion = table.Column<string>(nullable: true),
                    telefono = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    fechaIngreso = table.Column<DateTime>(nullable: false),
                    fechaEgreso = table.Column<DateTime>(nullable: false),
                    fechaRetiro = table.Column<DateTime>(nullable: false),
                    estadoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.id);
                    table.ForeignKey(
                        name: "FK_Estudiante_TipoDocumento_TipoDocumentoid",
                        column: x => x.TipoDocumentoid,
                        principalSchema: "GET",
                        principalTable: "TipoDocumento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Estudiante_EstadoEstudiante_estadoid",
                        column: x => x.estadoid,
                        principalSchema: "GET",
                        principalTable: "EstadoEstudiante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                schema: "GET",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(nullable: true),
                    apellido = table.Column<string>(nullable: true),
                    documento = table.Column<string>(nullable: true),
                    tipoDocumentoid = table.Column<int>(nullable: true),
                    estadoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.id);
                    table.ForeignKey(
                        name: "FK_Profesor_EstadoProfesor_estadoid",
                        column: x => x.estadoid,
                        principalSchema: "GET",
                        principalTable: "EstadoProfesor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profesor_TipoDocumento_tipoDocumentoid",
                        column: x => x.tipoDocumentoid,
                        principalSchema: "GET",
                        principalTable: "TipoDocumento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstudiantesXMateria",
                schema: "GET",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    estudianteid = table.Column<int>(nullable: true),
                    materiaid = table.Column<int>(nullable: true),
                    estadoid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiantesXMateria", x => x.id);
                    table.ForeignKey(
                        name: "FK_EstudiantesXMateria_EstadoMateriaEstudiante_estadoid",
                        column: x => x.estadoid,
                        principalSchema: "GET",
                        principalTable: "EstadoMateriaEstudiante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstudiantesXMateria_Estudiante_estudianteid",
                        column: x => x.estudianteid,
                        principalSchema: "GET",
                        principalTable: "Estudiante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstudiantesXMateria_Materia_materiaid",
                        column: x => x.materiaid,
                        principalSchema: "GET",
                        principalTable: "Materia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfesoresXMateria",
                schema: "GET",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    profesorid = table.Column<int>(nullable: true),
                    materiaid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesoresXMateria", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProfesoresXMateria_Materia_materiaid",
                        column: x => x.materiaid,
                        principalSchema: "GET",
                        principalTable: "Materia",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfesoresXMateria_Profesor_profesorid",
                        column: x => x.profesorid,
                        principalSchema: "GET",
                        principalTable: "Profesor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_TipoDocumentoid",
                schema: "GET",
                table: "Estudiante",
                column: "TipoDocumentoid");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_documento",
                schema: "GET",
                table: "Estudiante",
                column: "documento",
                unique: true,
                filter: "[documento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_estadoid",
                schema: "GET",
                table: "Estudiante",
                column: "estadoid");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantesXMateria_estadoid",
                schema: "GET",
                table: "EstudiantesXMateria",
                column: "estadoid");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantesXMateria_estudianteid",
                schema: "GET",
                table: "EstudiantesXMateria",
                column: "estudianteid");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiantesXMateria_materiaid",
                schema: "GET",
                table: "EstudiantesXMateria",
                column: "materiaid");

            migrationBuilder.CreateIndex(
                name: "IX_Materia_codigo",
                schema: "GET",
                table: "Materia",
                column: "codigo",
                unique: true,
                filter: "[codigo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_documento",
                schema: "GET",
                table: "Profesor",
                column: "documento",
                unique: true,
                filter: "[documento] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_estadoid",
                schema: "GET",
                table: "Profesor",
                column: "estadoid");

            migrationBuilder.CreateIndex(
                name: "IX_Profesor_tipoDocumentoid",
                schema: "GET",
                table: "Profesor",
                column: "tipoDocumentoid");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesoresXMateria_materiaid",
                schema: "GET",
                table: "ProfesoresXMateria",
                column: "materiaid");

            migrationBuilder.CreateIndex(
                name: "IX_ProfesoresXMateria_profesorid",
                schema: "GET",
                table: "ProfesoresXMateria",
                column: "profesorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudiantesXMateria",
                schema: "GET");

            migrationBuilder.DropTable(
                name: "ProfesoresXMateria",
                schema: "GET");

            migrationBuilder.DropTable(
                name: "EstadoMateriaEstudiante",
                schema: "GET");

            migrationBuilder.DropTable(
                name: "Estudiante",
                schema: "GET");

            migrationBuilder.DropTable(
                name: "Materia",
                schema: "GET");

            migrationBuilder.DropTable(
                name: "Profesor",
                schema: "GET");

            migrationBuilder.DropTable(
                name: "EstadoEstudiante",
                schema: "GET");

            migrationBuilder.DropTable(
                name: "EstadoProfesor",
                schema: "GET");

            migrationBuilder.DropTable(
                name: "TipoDocumento",
                schema: "GET");
        }
    }
}
