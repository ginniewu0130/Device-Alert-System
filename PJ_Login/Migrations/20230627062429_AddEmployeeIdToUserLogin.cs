using Microsoft.EntityFrameworkCore.Migrations;

namespace PJ_Login.Migrations
{
    public partial class AddEmployeeIdToUserLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "UserLogins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "UserLogins");

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "UserId", "Account", "Password" },
                values: new object[] { 1, "test001", "12345" });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "UserId", "Account", "Password" },
                values: new object[] { 2, "test002", "12345" });
        }
    }
}
