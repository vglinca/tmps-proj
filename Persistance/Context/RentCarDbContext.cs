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
				.UseSqlServer(@"Server=.;Database=RentCarDb;Trusted_Connection=True;");
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
