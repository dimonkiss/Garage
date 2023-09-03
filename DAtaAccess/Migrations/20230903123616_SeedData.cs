using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "test", "test" },
                    { 2, "test1", "test1" },
                    { 3, "test2", "test2" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Color", "ImagePath", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Test", "https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Mercedes-Benz_CLS_C218_63_AMG_China_2012-04-15.jpg/1024px-Mercedes-Benz_CLS_C218_63_AMG_China_2012-04-15.jpg", "Merdedes CLS 63", 1000 },
                    { 2, 2, "Test1", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e2/Porsche_Carrera_4S_front_20080519.jpg/1024px-Porsche_Carrera_4S_front_20080519.jpg", "Porsche 997", 1001 },
                    { 3, 3, "Test2", "https://uk.wikipedia.org/wiki/%D0%A4%D0%B0%D0%B9%D0%BB:Audi_RS6_Avant_C8_1X7A0305.jpg", "Audi RS6", 1002 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
