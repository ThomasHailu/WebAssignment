using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Management_System.Migrations
{
    public partial class ManageRoomConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ManageRooms_RegisterPatientId",
                table: "ManageRooms",
                column: "RegisterPatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManageRooms_RegisterPatients_RegisterPatientId",
                table: "ManageRooms",
                column: "RegisterPatientId",
                principalTable: "RegisterPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManageRooms_RegisterPatients_RegisterPatientId",
                table: "ManageRooms");

            migrationBuilder.DropIndex(
                name: "IX_ManageRooms_RegisterPatientId",
                table: "ManageRooms");
        }
    }
}
