using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CredVault.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Username" },
                values: new object[,]
                {
                    { new Guid("38aa6d36-5f9a-4925-a906-0d2c69193f40"), "mike.dev99@email.com", "mike.dev99" },
                    { new Guid("58e1fd2b-e7b3-475f-a8a1-6f0412bd23c0"), "emma_writer@email.com", "emma_writer" },
                    { new Guid("710b7450-60dc-475c-b783-4bcc094895c7"), "jason.lee@email.com", "jason.lee" },
                    { new Guid("968be66d-6c13-4f92-a9af-cac14c0f6cb4"), "mike.dev99@email.com", "mike.dev99" },
                    { new Guid("a818efb1-28a7-4df9-a655-8ca53ffaf420"), "samantha23@email.com", "samantha23" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("38aa6d36-5f9a-4925-a906-0d2c69193f40"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("58e1fd2b-e7b3-475f-a8a1-6f0412bd23c0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("710b7450-60dc-475c-b783-4bcc094895c7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("968be66d-6c13-4f92-a9af-cac14c0f6cb4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a818efb1-28a7-4df9-a655-8ca53ffaf420"));
        }
    }
}
