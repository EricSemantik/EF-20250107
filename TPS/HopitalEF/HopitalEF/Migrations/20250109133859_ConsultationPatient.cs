using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HopitalEF.Migrations
{
    /// <inheritdoc />
    public partial class ConsultationPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "consultation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_consultation_PatientId",
                table: "consultation",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_consultation_personne_PatientId",
                table: "consultation",
                column: "PatientId",
                principalTable: "personne",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_consultation_personne_PatientId",
                table: "consultation");

            migrationBuilder.DropIndex(
                name: "IX_consultation_PatientId",
                table: "consultation");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "consultation");
        }
    }
}
