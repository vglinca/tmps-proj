using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientTypes",
                columns: table => new
                {
                    ClientTypeId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTypes", x => x.ClientTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transmission",
                columns: table => new
                {
                    TransmissionTypeId = table.Column<long>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmission", x => x.TransmissionTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ClientTypeId = table.Column<long>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_ClientTypes_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "ClientTypes",
                        principalColumn: "ClientTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(nullable: true),
                    PricePerDay = table.Column<int>(nullable: false),
                    EngineDetails = table.Column<string>(nullable: true),
                    FuelTypeId = table.Column<long>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Back = table.Column<string>(nullable: true),
                    TransmissionTypeId = table.Column<long>(nullable: false),
                    TransmissionTypeId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Transmission_TransmissionTypeId1",
                        column: x => x.TransmissionTypeId1,
                        principalTable: "Transmission",
                        principalColumn: "TransmissionTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentContracts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(nullable: false),
                    RentStartDate = table.Column<DateTime>(nullable: false),
                    RentEndDate = table.Column<DateTime>(nullable: false),
                    Iban = table.Column<string>(nullable: true),
                    RentCost = table.Column<int>(nullable: false),
                    CarId = table.Column<long>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    InternationalDriverLicenseId = table.Column<string>(nullable: true),
                    PassportIdentifier = table.Column<string>(nullable: true),
                    VisaIdentifier = table.Column<string>(nullable: true),
                    MigrationNumber = table.Column<string>(nullable: true),
                    CompanyRegistrationDate = table.Column<DateTime>(nullable: true),
                    CompanyAddress = table.Column<string>(nullable: true),
                    UpperHouseExtractIdentifier = table.Column<string>(nullable: true),
                    AdministrationPassportIdentifier = table.Column<string>(nullable: true),
                    DriverLicenseIdentifier = table.Column<string>(nullable: true),
                    GeneralManagerSignatureIdentifier = table.Column<string>(nullable: true),
                    Idno = table.Column<string>(nullable: true),
                    DriverLicenseId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentContracts_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentContracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientTypes",
                columns: new[] { "ClientTypeId", "Title" },
                values: new object[,]
                {
                    { 0L, "Foreigner" },
                    { 1L, "PhysicalPerson" },
                    { 2L, "JuridicalPerson" }
                });

            migrationBuilder.InsertData(
                table: "Transmission",
                columns: new[] { "TransmissionTypeId", "Title" },
                values: new object[,]
                {
                    { 0L, "Mechanic" },
                    { 1L, "Automat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FuelTypeId",
                table: "Cars",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TransmissionTypeId1",
                table: "Cars",
                column: "TransmissionTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientTypeId",
                table: "Clients",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentContracts_CarId",
                table: "RentContracts",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentContracts_ClientId",
                table: "RentContracts",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentContracts");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "Transmission");

            migrationBuilder.DropTable(
                name: "ClientTypes");
        }
    }
}
