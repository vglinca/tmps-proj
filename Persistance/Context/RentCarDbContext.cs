using Microsoft.EntityFrameworkCore;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Persistance.Context
{
	public class RentCarDbContext : DbContext
	{
		
		public DbSet<Car> Cars { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<ClientType> ClientTypes { get; set; }
		public DbSet<RentContract> RentContracts { get; set; }
		public DbSet<JuridicalPersonRentContract> JurPersonRentContracts { get; set; }
		public DbSet<PhysicalPersonRentContract> PhPersonRentContracts { get; set; }
		public DbSet<ForeignerRentContract> ForeignerRentContracts { get; set; }
		public DbSet<FuelType> FuelTypes { get; set; }
		public DbSet<Transmission> Transmission { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseSqlServer(@"Server=.;Database=RentCarDb;Trusted_Connection=True;")
				.UseLazyLoadingProxies();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
				.Where(t => !string.IsNullOrWhiteSpace(t.Namespace))
				.Where(t => t.BaseType != null && t.BaseType.IsInterface
											   && t.BaseType.IsGenericType
											   && t.BaseType.GetGenericTypeDefinition() ==
											   typeof(IEntityTypeConfiguration<>));
			foreach (var type in typesToRegister)
			{
				dynamic configInstance = Activator.CreateInstance(type);
				modelBuilder.ApplyConfiguration(configInstance);
			}

			SeedData(modelBuilder);
		}

		private void SeedData(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<FuelType>().HasData(new List<FuelType>
			{
				new FuelType
				{
					Id = 1, Title = "Gasoline",
				},
				new FuelType
				{
					Id = 2, Title = "Diesel"
				}
			});

			modelBuilder.Entity<Car>().HasData(new List<Car>
			{
				new Car
				{
					Id = 1,
					ModelName = "RANGE ROVER SPORT 2014",
					PricePerDay = 80,
					Back = "SUV",
					Color = "Black",
					EngineDetails = "3.0d AT 190 kW / 258 Bhp",
					FuelTypeId = 2,
					TransmissionTypeId = TransmissionTypeId.Automat
				},
				new Car
				{
					Id = 2,
					ModelName = "MERCEDES-BENZ S350 2015",
					PricePerDay = 100,
					Back = "Sedan",
					Color = "Metallic Gri",
					EngineDetails = "3.0d AT 4WD 190 kW / 258 Bhp",
					FuelTypeId = 2,
					TransmissionTypeId = TransmissionTypeId.Automat
				},
				new Car
				{
					Id = 3,
					ModelName = "BMW X6 2015",
					PricePerDay = 90,
					Back = "Crossover",
					Color = "White",
					EngineDetails = "40d 3.0d AT 4WD 230 kW / 313 Bhp",
					FuelTypeId = 2,
					TransmissionTypeId = TransmissionTypeId.Automat
				},
				new Car
				{
					Id = 4,
					ModelName = "BMW 320I 2016",
					PricePerDay = 40,
					Back = "Sedan",
					Color = "Night Blue",
					EngineDetails = "2000 Engine 135 kW / 184 bhp",
					FuelTypeId = 1,
					TransmissionTypeId = TransmissionTypeId.Automat
				}
			});


			modelBuilder.Entity<Transmission>().HasKey(t => t.TransmissionTypeId);
			modelBuilder.Entity<ClientType>().HasKey(ct => ct.ClientTypeId);
			modelBuilder.Entity<Transmission>()
				.HasData(
					Enum.GetValues(typeof(TransmissionTypeId))
					.Cast<TransmissionTypeId>()
					.Select(t => new Transmission
					{
						TransmissionTypeId = t,
						Title = t.ToString()
					}));

			modelBuilder.Entity<ClientType>()
				.HasData(
					Enum.GetValues(typeof(ClientTypeId))
					.Cast<ClientTypeId>()
					.Select(ct => new ClientType
					{
						ClientTypeId = ct,
						Title = ct.ToString()
					}));
		}
	}
}
