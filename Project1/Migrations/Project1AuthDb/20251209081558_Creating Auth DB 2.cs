using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1.Migrations.Project1AuthDb
{
    /// <inheritdoc />
    public partial class CreatingAuthDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "189679fd-ff76-4c0e-9210-3cc91a76c48f", "189679fd-ff76-4c0e-9210-3cc91a76c48f", "Reader", "READER" },
                    { "9c971928-9d8f-4abd-a4a1-c3c6918ff8ed", "9c971928-9d8f-4abd-a4a1-c3c6918ff8ed", "Writer", "WRITER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "189679fd-ff76-4c0e-9210-3cc91a76c48f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9c971928-9d8f-4abd-a4a1-c3c6918ff8ed");
        }
    }
}
