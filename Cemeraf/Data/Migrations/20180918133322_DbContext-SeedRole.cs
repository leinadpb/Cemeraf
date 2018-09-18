using Microsoft.EntityFrameworkCore.Migrations;

namespace Cemeraf.Data.Migrations
{
    public partial class DbContextSeedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dd9ba29-8b99-4e15-b391-5cf541a743b2", "053d951f-b3b6-4259-a947-93afdf44a37b", "ADMINISTRATORS", "ADMINISTRATORS" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0dd9ba29-8b99-4e15-b391-5cf541a743b2", "053d951f-b3b6-4259-a947-93afdf44a37b" });
        }
    }
}
