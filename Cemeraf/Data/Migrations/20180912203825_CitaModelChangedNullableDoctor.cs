using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemeraf.Data.Migrations
{
    public partial class CitaModelChangedNullableDoctor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Doctors_DoctorId",
                table: "Citas");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Citas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Doctors_DoctorId",
                table: "Citas",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Doctors_DoctorId",
                table: "Citas");

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "Citas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Doctors_DoctorId",
                table: "Citas",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
