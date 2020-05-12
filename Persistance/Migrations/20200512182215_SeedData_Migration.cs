using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class SeedData_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1L, "Gasoline" });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2L, "Diesel" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Back", "Color", "EngineDetails", "FuelTypeId", "ModelName", "PricePerDay", "TransmissionTypeId", "TransmissionTypeId1" },
                values: new object[,]
                {
                    { 4L, "Sedan", "Night Blue", "2000 Engine 135 kW / 184 bhp", 1L, "BMW 320I 2016", 40, 1L, null },
                    { 1L, "SUV", "Black", "3.0d AT 190 kW / 258 Bhp", 2L, "RANGE ROVER SPORT 2014", 80, 1L, null },
                    { 2L, "Sedan", "Metallic Gri", "3.0d AT 4WD 190 kW / 258 Bhp", 2L, "MERCEDES-BENZ S350 2015", 100, 1L, null },
                    { 3L, "Crossover", "White", "40d 3.0d AT 4WD 230 kW / 313 Bhp", 2L, "BMW X6 2015", 90, 1L, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "FuelTypes",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
