using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemeraf.Data.Migrations
{
    public partial class CitaModelProposedDateAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateProposed",
                table: "Citas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateProposed",
                table: "Citas");
        }
    }
}
