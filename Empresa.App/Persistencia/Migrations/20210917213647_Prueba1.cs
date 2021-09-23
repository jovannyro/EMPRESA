using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class Prueba1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsClienteId = table.Column<int>(type: "int", nullable: true),
                    SueldoBruto = table.Column<int>(type: "int", nullable: true),
                    EmpleadorId = table.Column<int>(type: "int", nullable: true),
                    Categoria = table.Column<int>(type: "int", nullable: true),
                    SubordinadoId = table.Column<int>(type: "int", nullable: true),
                    DirigeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personas_Empresas_DirigeId",
                        column: x => x.DirigeId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Empresas_EmpleadorId",
                        column: x => x.EmpleadorId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Empresas_EsClienteId",
                        column: x => x.EsClienteId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personas_Personas_SubordinadoId",
                        column: x => x.SubordinadoId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_DirigeId",
                table: "Personas",
                column: "DirigeId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EmpleadorId",
                table: "Personas",
                column: "EmpleadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_EsClienteId",
                table: "Personas",
                column: "EsClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Personas_SubordinadoId",
                table: "Personas",
                column: "SubordinadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
