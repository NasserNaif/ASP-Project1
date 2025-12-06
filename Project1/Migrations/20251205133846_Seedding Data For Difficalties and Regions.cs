using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project1.Migrations
{
    /// <inheritdoc />
    public partial class SeeddingDataForDifficaltiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-4a7b-8c9d-1234567890ab"), "Medium" },
                    { new Guid("5d8f8c2e-1c4b-4d6a-9f3a-1a2b3c4d5e6f"), "Easy" },
                    { new Guid("abcdef12-3456-7890-abcd-ef1234567890"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0b672d11-62db-4375-d447-08de33ff7d41"), "RID", "Riyadh", "https://content.r9cdn.net/rimg/dimg/7d/60/488863c5-city-35744-16935f1b104.jpg?crop=true&width=1366&height=768&xhint=1725&yhint=1010" },
                    { new Guid("c9556526-4b65-40e0-d449-08de33ff7d41"), "DAM", "Dammam", "https://excursionmania.com/cdn-cgi/image/quality=75,format=webp,w=auto,h=auto,fit=scale-down,trim=border/https://excursionmania.com/uploads/blog/ideas/5b70a44f601894b4d4488bafc7ba3a7c.jpg" },
                    { new Guid("d31571fa-ccd2-41a8-d448-08de33ff7d41"), "JED", "Jeddah", "https://images.locationscout.net/2020/03/the-read-sea-saudi-arabia-hrrc.webp?h=1400&q=80" },
                    { new Guid("f2688dad-8762-4b3d-d44a-08de33ff7d41"), "MEC", "Mecca", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTPCPg1rQ5JXdtzMQmf_L5xrveh6o5vZMDgxQ&s" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1a2b3c4d-5e6f-4a7b-8c9d-1234567890ab"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5d8f8c2e-1c4b-4d6a-9f3a-1a2b3c4d5e6f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("abcdef12-3456-7890-abcd-ef1234567890"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0b672d11-62db-4375-d447-08de33ff7d41"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c9556526-4b65-40e0-d449-08de33ff7d41"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d31571fa-ccd2-41a8-d448-08de33ff7d41"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f2688dad-8762-4b3d-d44a-08de33ff7d41"));
        }
    }
}
