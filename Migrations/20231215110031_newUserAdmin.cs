using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyConverter.Migrations
{
    /// <inheritdoc />
    public partial class newUserAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Conversions", "Email", "Password", "Plan", "Role", "State", "Username" },
                values: new object[] { 1, 0, "fecarrizzo@gmail.com", "heisenberg", 2, 1, 0, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
