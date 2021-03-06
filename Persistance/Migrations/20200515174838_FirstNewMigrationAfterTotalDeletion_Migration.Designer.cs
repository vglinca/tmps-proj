﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance.Context;

namespace Persistance.Migrations
{
    [DbContext(typeof(RentCarDbContext))]
    [Migration("20200515174838_FirstNewMigrationAfterTotalDeletion_Migration")]
    partial class FirstNewMigrationAfterTotalDeletion_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Persistance.Entities.Car", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Back")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EngineDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FuelTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PricePerDay")
                        .HasColumnType("int");

                    b.Property<long>("TransmissionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FuelTypeId");

                    b.HasIndex("TransmissionId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Back = "SUV",
                            Color = "Black",
                            EngineDetails = "3.0d AT 190 kW / 258 Bhp",
                            FuelTypeId = 2L,
                            ModelName = "RANGE ROVER SPORT 2014",
                            PricePerDay = 80,
                            TransmissionId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Back = "Sedan",
                            Color = "Metallic Gri",
                            EngineDetails = "3.0d AT 4WD 190 kW / 258 Bhp",
                            FuelTypeId = 2L,
                            ModelName = "MERCEDES-BENZ S350 2015",
                            PricePerDay = 100,
                            TransmissionId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            Back = "Crossover",
                            Color = "White",
                            EngineDetails = "40d 3.0d AT 4WD 230 kW / 313 Bhp",
                            FuelTypeId = 2L,
                            ModelName = "BMW X6 2015",
                            PricePerDay = 90,
                            TransmissionId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            Back = "Sedan",
                            Color = "Night Blue",
                            EngineDetails = "2000 Engine 135 kW / 184 bhp",
                            FuelTypeId = 1L,
                            ModelName = "BMW 320I 2016",
                            PricePerDay = 40,
                            TransmissionId = 1L
                        });
                });

            modelBuilder.Entity("Persistance.Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ClientTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientTypeId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Persistance.Entities.ClientType", b =>
                {
                    b.Property<long>("ClientTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientTypeId");

                    b.ToTable("ClientTypes");

                    b.HasData(
                        new
                        {
                            ClientTypeId = 0L,
                            Title = "Foreigner"
                        },
                        new
                        {
                            ClientTypeId = 1L,
                            Title = "PhysicalPerson"
                        },
                        new
                        {
                            ClientTypeId = 2L,
                            Title = "JuridicalPerson"
                        });
                });

            modelBuilder.Entity("Persistance.Entities.FuelType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FuelTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Title = "Gasoline"
                        },
                        new
                        {
                            Id = 2L,
                            Title = "Diesel"
                        });
                });

            modelBuilder.Entity("Persistance.Entities.RentContract", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CarId")
                        .HasColumnType("bigint");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RentCost")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RentStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ClientId");

                    b.ToTable("RentContracts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("RentContract");
                });

            modelBuilder.Entity("Persistance.Entities.Transmission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transmission");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Title = "Automat"
                        },
                        new
                        {
                            Id = 2L,
                            Title = "Mechanic"
                        });
                });

            modelBuilder.Entity("Persistance.Entities.ForeignerRentContract", b =>
                {
                    b.HasBaseType("Persistance.Entities.RentContract");

                    b.Property<string>("InternationalDriverLicenseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MigrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VisaIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ForeignerRentContract");
                });

            modelBuilder.Entity("Persistance.Entities.JuridicalPersonRentContract", b =>
                {
                    b.HasBaseType("Persistance.Entities.RentContract");

                    b.Property<string>("AdministrationPassportIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CompanyRegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DriverLicenseIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneralManagerSignatureIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpperHouseExtractIdentifier")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("JuridicalPersonRentContract");
                });

            modelBuilder.Entity("Persistance.Entities.PhysicalPersonRentContract", b =>
                {
                    b.HasBaseType("Persistance.Entities.RentContract");

                    b.Property<string>("DriverLicenseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Idno")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PhysicalPersonRentContract");
                });

            modelBuilder.Entity("Persistance.Entities.Car", b =>
                {
                    b.HasOne("Persistance.Entities.FuelType", "FuelType")
                        .WithMany("Cars")
                        .HasForeignKey("FuelTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.Transmission", "Transmission")
                        .WithMany("Cars")
                        .HasForeignKey("TransmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Persistance.Entities.Client", b =>
                {
                    b.HasOne("Persistance.Entities.ClientType", "ClientType")
                        .WithMany("Clients")
                        .HasForeignKey("ClientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Persistance.Entities.RentContract", b =>
                {
                    b.HasOne("Persistance.Entities.Car", "Car")
                        .WithMany("RentContracts")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Persistance.Entities.Client", "Client")
                        .WithMany("RentContracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
