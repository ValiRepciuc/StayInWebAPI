using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StayIn.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57bebb0d-c553-4c22-a640-aaf52978e16a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abdcb8df-cc9a-41de-9859-de98ccd9c110");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b208509-1708-4275-a9c7-de0aac27d018", null, "User", "USER" },
                    { "6bb03ee1-8813-4179-b5cb-e970bf49afc1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b208509-1708-4275-a9c7-de0aac27d018");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bb03ee1-8813-4179-b5cb-e970bf49afc1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57bebb0d-c553-4c22-a640-aaf52978e16a", null, "User", "USER" },
                    { "abdcb8df-cc9a-41de-9859-de98ccd9c110", null, "Admin", "ADMIN" }
                });
        }
    }
}
