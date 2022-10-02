using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Management_System.Migrations
{
    public partial class cleanup3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDoctorApproved",
                table: "ManageAppointments");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "ManageAppointments");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "ManageAppointments",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "ManageAppointments",
                newName: "EndTime");

            migrationBuilder.AlterColumn<long>(
                name: "DoctorId",
                table: "ManageAppointments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ManageAppointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RegisterPatientId",
                table: "ManageAppointments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ManageAppointments_ApplicationUserId",
                table: "ManageAppointments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ManageAppointments_RegisterPatientId",
                table: "ManageAppointments",
                column: "RegisterPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageAppointments_AspNetUsers_ApplicationUserId",
                table: "ManageAppointments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ManageAppointments_RegisterPatients_RegisterPatientId",
                table: "ManageAppointments",
                column: "RegisterPatientId",
                principalTable: "RegisterPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManageAppointments_AspNetUsers_ApplicationUserId",
                table: "ManageAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_ManageAppointments_RegisterPatients_RegisterPatientId",
                table: "ManageAppointments");

            migrationBuilder.DropIndex(
                name: "IX_ManageAppointments_ApplicationUserId",
                table: "ManageAppointments");

            migrationBuilder.DropIndex(
                name: "IX_ManageAppointments_RegisterPatientId",
                table: "ManageAppointments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ManageAppointments");

            migrationBuilder.DropColumn(
                name: "RegisterPatientId",
                table: "ManageAppointments");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "ManageAppointments",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "ManageAppointments",
                newName: "EndDate");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "ManageAppointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<bool>(
                name: "IsDoctorApproved",
                table: "ManageAppointments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "ManageAppointments",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
