using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital_Management_System.Migrations
{
    public partial class editedlab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LabResultViewModels",
                table: "LabResultViewModels");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "LabResultViewModels");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "LabResultViewModels");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "LabResultViewModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabResultViewModels",
                table: "LabResultViewModels",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LabResultViewModels",
                table: "LabResultViewModels");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LabResultViewModels");

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "LabResultViewModels",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "LabResultViewModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LabResultViewModels",
                table: "LabResultViewModels",
                column: "ReportId");
        }
    }
}
