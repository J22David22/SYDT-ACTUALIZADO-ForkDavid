using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.App.Persistencia.Migrations
{
    public partial class migHospita87 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "SignosVitales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SignosVitales_PacienteId",
                table: "SignosVitales",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_SignosVitales_Personas_PacienteId",
                table: "SignosVitales",
                column: "PacienteId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SignosVitales_Personas_PacienteId",
                table: "SignosVitales");

            migrationBuilder.DropIndex(
                name: "IX_SignosVitales_PacienteId",
                table: "SignosVitales");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "SignosVitales");
        }
    }
}
