using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemeraf.Data.Migrations
{
    public partial class TablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Doctor_DoctorId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Specialty_Doctor_DoctorId",
                table: "Specialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor");

            migrationBuilder.RenameTable(
                name: "Specialty",
                newName: "Specialties");

            migrationBuilder.RenameTable(
                name: "Doctor",
                newName: "Doctors");

            migrationBuilder.RenameIndex(
                name: "IX_Specialty_DoctorId",
                table: "Specialties",
                newName: "IX_Specialties_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties",
                column: "SpecialtyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Doctors_DoctorId",
                table: "Citas",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialties_Doctors_DoctorId",
                table: "Specialties",
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

            migrationBuilder.DropForeignKey(
                name: "FK_Specialties_Doctors_DoctorId",
                table: "Specialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Specialties",
                table: "Specialties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doctors",
                table: "Doctors");

            migrationBuilder.RenameTable(
                name: "Specialties",
                newName: "Specialty");

            migrationBuilder.RenameTable(
                name: "Doctors",
                newName: "Doctor");

            migrationBuilder.RenameIndex(
                name: "IX_Specialties_DoctorId",
                table: "Specialty",
                newName: "IX_Specialty_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Specialty",
                table: "Specialty",
                column: "SpecialtyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doctor",
                table: "Doctor",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Doctor_DoctorId",
                table: "Citas",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Specialty_Doctor_DoctorId",
                table: "Specialty",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
