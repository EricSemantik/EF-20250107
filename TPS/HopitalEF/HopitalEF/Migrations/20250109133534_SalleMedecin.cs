using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HopitalEF.Migrations
{
    /// <inheritdoc />
    public partial class SalleMedecin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedecinId",
                table: "salle",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_salle_MedecinId",
                table: "salle",
                column: "MedecinId",
                unique: true,
                filter: "[MedecinId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_salle_personne_MedecinId",
                table: "salle",
                column: "MedecinId",
                principalTable: "personne",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_salle_personne_MedecinId",
                table: "salle");

            migrationBuilder.DropIndex(
                name: "IX_salle_MedecinId",
                table: "salle");

            migrationBuilder.DropColumn(
                name: "MedecinId",
                table: "salle");
        }
    }
}
