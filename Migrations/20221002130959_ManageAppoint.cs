using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Management_System.Migrations
{
    public partial class ManageAppoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManageAppointments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationUserId = table.Column<long>(type: "bigint", nullable: false),
                    RegisterPatientId = table.Column<long>(type: "bigint", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManageAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManageAppointments_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManageAppointments_RegisterPatients_RegisterPatientId",
                        column: x => x.RegisterPatientId,
                        principalTable: "RegisterPatients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManageAppointments_ApplicationUserId1",
                table: "ManageAppointments",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ManageAppointments_RegisterPatientId",
                table: "ManageAppointments",
                column: "RegisterPatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManageAppointments");
        }
    }
}
