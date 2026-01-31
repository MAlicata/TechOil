using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechOil.Migrations
{
    public partial class viernes0203 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "cod_trabajo",
                keyValue: 2,
                column: "fecha",
                value: new DateTime(2025, 10, 10, 20, 16, 47, 836, DateTimeKind.Local).AddTicks(658));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trabajos",
                keyColumn: "cod_trabajo",
                keyValue: 2,
                column: "fecha",
                value: new DateTime(2025, 10, 10, 20, 5, 23, 470, DateTimeKind.Local).AddTicks(5333));
        }
    }
}
