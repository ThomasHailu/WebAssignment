using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Management_System.Migrations
{
    public partial class prescribedrugfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "PrescribeDrugs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RegisterPatientId",
                table: "PrescribeDrugs",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrescribeDrugs_RegisterPatientId",
                table: "PrescribeDrugs",
                column: "RegisterPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribeDrugs_RegisterPatients_RegisterPatientId",
                table: "PrescribeDrugs",
                column: "RegisterPatientId",
                principalTable: "RegisterPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescribeDrugs_RegisterPatients_RegisterPatientId",
                table: "PrescribeDrugs");

            migrationBuilder.DropIndex(
                name: "IX_PrescribeDrugs_RegisterPatientId",
                table: "PrescribeDrugs");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PrescribeDrugs");

            migrationBuilder.DropColumn(
                name: "RegisterPatientId",
                table: "PrescribeDrugs");
        }
    }
}
