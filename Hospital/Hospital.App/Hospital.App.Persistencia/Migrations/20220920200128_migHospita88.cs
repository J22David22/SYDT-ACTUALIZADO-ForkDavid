using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.App.Persistencia.Migrations
{
    public partial class migHospita88 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistoriaClinicaId",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Entorno",
                table: "HistoriasClinicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Diagnostico",
                table: "HistoriasClinicas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "HistoriasClinicas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "HistoriasClinicas",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HistoriaClinicaId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "HistoriasClinicas");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "HistoriasClinicas");

            migrationBuilder.AlterColumn<string>(
                name: "Entorno",
                table: "HistoriasClinicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Diagnostico",
                table: "HistoriasClinicas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
