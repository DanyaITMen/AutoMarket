using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoMarket.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "Role" },
                values: new object[] { "user123", "test@example.com", "test123", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "user123");
        }
    }
}
