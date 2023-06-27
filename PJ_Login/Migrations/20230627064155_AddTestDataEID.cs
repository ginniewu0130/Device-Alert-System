using Microsoft.EntityFrameworkCore.Migrations;

namespace PJ_Login.Migrations
{
    public partial class AddTestDataEID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "UserLogins",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "UserId", "Account", "EmployeeId", "Password" },
                values: new object[] { 1, "test001", "E001", "12345" });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "UserId", "Account", "EmployeeId", "Password" },
                values: new object[] { 2, "test002", "E002", "12345" });
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

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                table: "UserLogins",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
