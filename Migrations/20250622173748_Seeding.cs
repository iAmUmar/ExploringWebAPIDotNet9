using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExploringWebAPIDotNet9.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Course", "DateOfBirth", "Fees", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "123 Main St", "Computer Science", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, "John Doe", "123-456-7890" },
                    { 2, "456 Elm St", "Mathematics", new DateTime(1999, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200, "Jane Smith", "987-654-3210" },
                    { 3, "786 Elm St", "History", new DateTime(1999, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500, "Will Turner", "456-789-1400" },
                    { 4, "345 Dhoke Paracha", "Litrature", new DateTime(1993, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1100, "Muhammad Umar", "312-4747-481" },
                    { 5, "421 Satellite Town", "Science", new DateTime(1994, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1400, "Jack Sparrow", "312-4324-567" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
