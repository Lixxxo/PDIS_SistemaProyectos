using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaProyectos.Migrations
{
    public partial class _0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "TaskMaterials",
                newName: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TaskMaterials",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TaskMaterials",
                newName: "Hour");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Hour",
                table: "TaskMaterials",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }
    }
}
