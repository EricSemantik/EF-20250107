using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HopitalEF.Migrations
{
    /// <inheritdoc />
    public partial class ConsultationMedecin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedecinId",
                table: "consultation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_consultation_MedecinId",
                table: "consultation",
                column: "MedecinId");

            migrationBuilder.AddForeignKey(
                name: "FK_consultation_personne_MedecinId",
                table: "consultation",
                column: "MedecinId",
                principalTable: "personne",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_consultation_personne_MedecinId",
                table: "consultation");

            migrationBuilder.DropIndex(
                name: "IX_consultation_MedecinId",
                table: "consultation");

            migrationBuilder.DropColumn(
                name: "MedecinId",
                table: "consultation");
        }
    }
}
