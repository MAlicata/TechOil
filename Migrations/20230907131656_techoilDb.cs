using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOil.Migrations
{
    public partial class techoilDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    cod_proyecto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    direccion = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    estado_proyecto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.cod_proyecto);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    cod_servicio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descr = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    estado_servicio = table.Column<int>(type: "int", nullable: false),
                    valor_hora = table.Column<decimal>(type: "DECIMAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.cod_servicio);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    cod_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    dni = table.Column<int>(type: "int", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.cod_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Trabajos",
                columns: table => new
                {
                    cod_trabajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cod_proyecto = table.Column<int>(type: "int", nullable: false),
                    cod_servicio = table.Column<int>(type: "int", nullable: false),
                    cant_horas = table.Column<int>(type: "int", nullable: false),
                    valor_hora = table.Column<decimal>(type: "Decimal", nullable: false),
                    costo = table.Column<decimal>(type: "DECIMAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trabajos", x => x.cod_trabajo);
                    table.ForeignKey(
                        name: "FK_Trabajos_Proyectos_cod_proyecto",
                        column: x => x.cod_proyecto,
                        principalTable: "Proyectos",
                        principalColumn: "cod_proyecto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trabajos_Servicios_cod_servicio",
                        column: x => x.cod_servicio,
                        principalTable: "Servicios",
                        principalColumn: "cod_servicio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Proyectos",
                columns: new[] { "cod_proyecto", "direccion", "estado_proyecto", "nombre" },
                values: new object[] { 9, "San Miguel de tucuman", 2, "Desarrollo de Api Web" });

            migrationBuilder.InsertData(
                table: "Servicios",
                columns: new[] { "cod_servicio", "descr", "estado_servicio", "valor_hora" },
                values: new object[] { 5, "Servicio de Marketing", 0, 100m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "cod_usuario", "clave", "dni", "nombre", "tipo" },
                values: new object[] { 1, "1234", 12345678, "Matias", 1 });

            migrationBuilder.InsertData(
                table: "Trabajos",
                columns: new[] { "cod_trabajo", "cant_horas", "cod_proyecto", "cod_servicio", "costo", "fecha", "valor_hora" },
                values: new object[] { 2, 20, 9, 5, 2000m, new DateTime(2023, 9, 7, 10, 16, 55, 741, DateTimeKind.Local).AddTicks(1442), 100m });

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_cod_proyecto",
                table: "Trabajos",
                column: "cod_proyecto");

            migrationBuilder.CreateIndex(
                name: "IX_Trabajos_cod_servicio",
                table: "Trabajos",
                column: "cod_servicio");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trabajos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Servicios");
        }
    }
}
