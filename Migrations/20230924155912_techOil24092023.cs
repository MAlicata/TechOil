using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOil.Migrations
{
    public partial class techOil24092023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_eliminacion",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "fecha_eliminacion",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "fecha_eliminacion",
                table: "Proyectos");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Trabajos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Servicios",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Proyectos",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "cod_trabajo",
                keyValue: 2,
                column: "fecha",
                value: new DateTime(2023, 9, 24, 12, 59, 11, 668, DateTimeKind.Local).AddTicks(5079));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Trabajos");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Servicios");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Proyectos");

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
                value: new DateTime(2023, 9, 24, 11, 54, 4, 45, DateTimeKind.Local).AddTicks(7523));
        }
    }
}
