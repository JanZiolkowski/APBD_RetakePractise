using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PractiseScratch.Migrations
{
    /// <inheritdoc />
    public partial class MockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "IdActor", "Name", "Nickname", "Surname" },
                values: new object[,]
                {
                    { 1, "John", "Vigor", "Miguells" },
                    { 2, "Vera", "Kiss", "Bailla" },
                    { 3, "Ala", "Vigra", "Piska" }
                });

            migrationBuilder.InsertData(
                table: "AgeRating",
                columns: new[] { "IdAgeRating", "Name" },
                values: new object[,]
                {
                    { 1, "Underage" },
                    { 2, "Age" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "IdMovie", "IdAgeRating", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 1, "James Bond", new DateTime(2024, 3, 23, 21, 24, 48, 449, DateTimeKind.Local).AddTicks(3831) },
                    { 2, 2, "Query", new DateTime(2024, 5, 23, 21, 24, 48, 449, DateTimeKind.Local).AddTicks(3897) }
                });

            migrationBuilder.InsertData(
                table: "Actor_Movie",
                columns: new[] { "IdActor", "IdMovie", "CharacterName" },
                values: new object[,]
                {
                    { 1, 1, "Bear" },
                    { 2, 1, "Herrassa" },
                    { 2, 2, "Jinxa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "IdActor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actor_Movie",
                keyColumns: new[] { "IdActor", "IdMovie" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Actor_Movie",
                keyColumns: new[] { "IdActor", "IdMovie" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Actor_Movie",
                keyColumns: new[] { "IdActor", "IdMovie" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "IdActor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "IdActor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "IdMovie",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "IdMovie",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AgeRating",
                keyColumn: "IdAgeRating",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AgeRating",
                keyColumn: "IdAgeRating",
                keyValue: 2);
        }
    }
}
