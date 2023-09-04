using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImagePath", "Name" },
                values: new object[] { "https://upload.wikimedia.org/wikipedia/commons/thumb/6/65/Audi_RS7_C8_at_IAA_2019_IMG_0307.jpg/1024px-Audi_RS7_C8_at_IAA_2019_IMG_0307.jpg", "Audi RS7" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "Color", "ImagePath", "Name", "Price" },
                values: new object[] { 4, 3, "Test", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4d/Kunmadaras_Motorsport_2021._szeptember_19._JM_%28157%29.jpg/1024px-Kunmadaras_Motorsport_2021._szeptember_19._JM_%28157%29.jpg", "BMW M5", 1003 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImagePath", "Name" },
                values: new object[] { "https://uk.wikipedia.org/wiki/%D0%A4%D0%B0%D0%B9%D0%BB:Audi_RS6_Avant_C8_1X7A0305.jpg", "Audi RS6" });
        }
    }
}
