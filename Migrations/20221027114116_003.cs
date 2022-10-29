using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaProyectos.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskMaterials_Materials_MaterialId",
                table: "TaskMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskMaterials_Tasks_TaskId",
                table: "TaskMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "TaskMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "TaskMaterials",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMaterials_Materials_MaterialId",
                table: "TaskMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMaterials_Tasks_TaskId",
                table: "TaskMaterials",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskMaterials_Materials_MaterialId",
                table: "TaskMaterials");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskMaterials_Tasks_TaskId",
                table: "TaskMaterials");

            migrationBuilder.AlterColumn<int>(
                name: "TaskId",
                table: "TaskMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "TaskMaterials",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMaterials_Materials_MaterialId",
                table: "TaskMaterials",
                column: "MaterialId",
                principalTable: "Materials",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskMaterials_Tasks_TaskId",
                table: "TaskMaterials",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id");
        }
    }
}
