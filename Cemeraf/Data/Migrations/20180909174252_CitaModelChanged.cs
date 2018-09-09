using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemeraf.Data.Migrations
{
    public partial class CitaModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Citas_CitaId1",
                table: "Citas");

            migrationBuilder.DropIndex(
                name: "IX_Citas_CitaId1",
                table: "Citas");

            migrationBuilder.DropColumn(
                name: "CitaId1",
                table: "Citas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CitaId1",
                table: "Citas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_CitaId1",
                table: "Citas",
                column: "CitaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Citas_CitaId1",
                table: "Citas",
                column: "CitaId1",
                principalTable: "Citas",
                principalColumn: "CitaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
