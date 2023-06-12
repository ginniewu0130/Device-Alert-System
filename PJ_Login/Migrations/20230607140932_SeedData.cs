using Microsoft.EntityFrameworkCore.Migrations;

namespace PJ_Login.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "UserId", "Account", "Password" },
                values: new object[] { 1, "test001", "12345" });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "UserId", "Account", "Password" },
                values: new object[] { 2, "test002", "12345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "UserId",
                keyValue: 2);
        }
    }
}
