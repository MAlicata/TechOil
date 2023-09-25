using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOil.Migrations
{
    public partial class techOil2409 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_eliminacion",
                table: "Usuarios");

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "Usuarios",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "cod_trabajo",
                keyValue: 2,
                column: "fecha",
                value: new DateTime(2023, 9, 24, 11, 54, 4, 45, DateTimeKind.Local).AddTicks(7523));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "Usuarios");

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_eliminacion",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "cod_trabajo",
                keyValue: 2,
                column: "fecha",
                value: new DateTime(2023, 9, 24, 0, 57, 0, 397, DateTimeKind.Local).AddTicks(4890));
        }
    }
}
