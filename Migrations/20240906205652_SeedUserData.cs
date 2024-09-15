using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class SeedUserData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { 1, "12345", "admin" });
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
