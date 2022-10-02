using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Management_System.Migrations
{
    public partial class prescribedrugfk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescribeDrugs_RegisterPatients_RegisterPatientId",
                table: "PrescribeDrugs");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "PrescribeDrugs");

            migrationBuilder.AlterColumn<long>(
                name: "RegisterPatientId",
                table: "PrescribeDrugs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribeDrugs_RegisterPatients_RegisterPatientId",
                table: "PrescribeDrugs",
                column: "RegisterPatientId",
                principalTable: "RegisterPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PrescribeDrugs_RegisterPatients_RegisterPatientId",
                table: "PrescribeDrugs");

            migrationBuilder.AlterColumn<long>(
                name: "RegisterPatientId",
                table: "PrescribeDrugs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "PrescribeDrugs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribeDrugs_RegisterPatients_RegisterPatientId",
                table: "PrescribeDrugs",
                column: "RegisterPatientId",
                principalTable: "RegisterPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
