using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configuration
{
	public class CarConfig : IEntityTypeConfiguration<Car>
	{
		public void Configure(EntityTypeBuilder<Car> builder)
		{
			builder.HasOne(c => c.FuelType)
					.WithMany(f => f.Cars)
					.HasForeignKey(c => c.FuelTypeId)
					.OnDelete(DeleteBehavior.Cascade);
			builder.Property(c => c.TransmissionTypeId)
					.HasConversion<long>();
			builder.HasOne(c => c.Transmission)
					.WithMany(t => t.Cars)
					.HasForeignKey(c => c.TransmissionTypeId)
					.OnDelete(DeleteBehavior.Cascade);
			builder.HasMany(c => c.RentContracts)
					.WithOne(rc => rc.Car)
					.HasForeignKey(rc => rc.CarId)
					.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
