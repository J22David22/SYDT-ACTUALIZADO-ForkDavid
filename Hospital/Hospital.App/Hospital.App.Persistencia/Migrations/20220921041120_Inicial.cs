using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.App.Persistencia.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_MedicoId",
                table: "Personas");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "HistoriasClinicas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "HistoriasClinicas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_MedicoId",
                table: "Personas",
                column: "MedicoId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Personas_MedicoId",
                table: "Personas");

            migrationBuilder.AlterColumn<int>(
                name: "PacienteId",
                table: "HistoriasClinicas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicoId",
                table: "HistoriasClinicas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Personas_MedicoId",
                table: "Personas",
                column: "MedicoId",
                principalTable: "Personas",
                principalColumn: "Id");
        }
    }
}
