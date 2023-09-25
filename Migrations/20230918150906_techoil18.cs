using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOil.Migrations
{
    public partial class techoil18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "cod_proyecto",
                keyValue: 9,
                columns: new[] { "direccion", "nombre" },
                values: new object[] { "San Miguel de Tucuman", "Planta de Gas - Zona 1" });

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "cod_servicio",
                keyValue: 5,
                columns: new[] { "descr", "estado_servicio" },
                values: new object[] { "Servicio de Refinamiento de Gas", 1 });

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "cod_trabajo",
                keyValue: 2,
                column: "fecha",
                value: new DateTime(2023, 9, 18, 12, 9, 6, 461, DateTimeKind.Local).AddTicks(6834));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "cod_usuario",
                keyValue: 1,
                column: "usuario_email",
                value: "matias@hotmail.com.ar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Proyectos",
                keyColumn: "cod_proyecto",
                keyValue: 9,
                columns: new[] { "direccion", "nombre" },
                values: new object[] { "San Miguel de tucuman", "Desarrollo de Api Web" });

            migrationBuilder.UpdateData(
                table: "Servicios",
                keyColumn: "cod_servicio",
                keyValue: 5,
                columns: new[] { "descr", "estado_servicio" },
                values: new object[] { "Servicio de Marketing", 0 });

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "cod_trabajo",
                keyValue: 2,
                column: "fecha",
                value: new DateTime(2023, 9, 14, 11, 14, 36, 683, DateTimeKind.Local).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "cod_usuario",
                keyValue: 1,
                column: "usuario_email",
                value: "matias1995@hotmail.com.ar");
        }
    }
}
