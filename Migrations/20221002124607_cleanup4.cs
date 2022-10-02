using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Management_System.Migrations
{
    public partial class cleanup4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManageAppointments_AspNetUsers_ApplicationUserId",
                table: "ManageAppointments");

            migrationBuilder.DropIndex(
                name: "IX_ManageAppointments_ApplicationUserId",
                table: "ManageAppointments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "ManageAppointments");

            migrationBuilder.AlterColumn<long>(
                name: "ApplicationUserId",
                table: "ManageAppointments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "ManageAppointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManageAppointments_ApplicationUserId1",
                table: "ManageAppointments",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageAppointments_AspNetUsers_ApplicationUserId1",
                table: "ManageAppointments",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManageAppointments_AspNetUsers_ApplicationUserId1",
                table: "ManageAppointments");

            migrationBuilder.DropIndex(
                name: "IX_ManageAppointments_ApplicationUserId1",
                table: "ManageAppointments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "ManageAppointments");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "ManageAppointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "DoctorId",
                table: "ManageAppointments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ManageAppointments_ApplicationUserId",
                table: "ManageAppointments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageAppointments_AspNetUsers_ApplicationUserId",
                table: "ManageAppointments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
