using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOil.Migrations
{
    public partial class techOilDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "clave",
                table: "Usuarios",
                type: "VARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_eliminacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_eliminacion",
                table: "Trabajos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_eliminacion",
                table: "Servicios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_eliminacion",
                table: "Proyectos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "cod_trabajo",
                keyValue: 2,
                column: "fecha",
                value: new DateTime(2023, 9, 24, 0, 57, 0, 397, DateTimeKind.Local).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "cod_usuario",
                keyValue: 1,
                column: "clave",
                value: "588acee9920f023bfe4b60ff2def822ee7612d12f620db6677d637e799315884");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_eliminacion",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "fecha_eliminacion",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "fecha_eliminacion",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "fecha_eliminacion",
                table: "Proyectos");

            migrationBuilder.AlterColumn<string>(
                name: "clave",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(250)");

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
                column: "clave",
                value: "1234");
        }
    }
}
