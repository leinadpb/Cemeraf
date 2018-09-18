using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemeraf.Data.Migrations
{
    public partial class DoctorModelChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0dd9ba29-8b99-4e15-b391-5cf541a743b2", "053d951f-b3b6-4259-a947-93afdf44a37b" });

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "Doctors",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "47b6852b-33f6-4eea-acca-b9a716f288da", "3d94d877-d7ed-4298-a6fb-3bf0fac4ab96", "ADMINISTRATORS", "ADMINISTRATORS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "47b6852b-33f6-4eea-acca-b9a716f288da", "3d94d877-d7ed-4298-a6fb-3bf0fac4ab96" });

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "Doctors");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dd9ba29-8b99-4e15-b391-5cf541a743b2", "053d951f-b3b6-4259-a947-93afdf44a37b", "ADMINISTRATORS", "ADMINISTRATORS" });
        }
    }
}
