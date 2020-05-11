using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configuration
{
	public class PhysicalPersonRentContractConfig : IEntityTypeConfiguration<PhysicalPersonRentContract>
	{
		public void Configure(EntityTypeBuilder<PhysicalPersonRentContract> builder)
		{
			builder.Property(p => p.Idno).IsRequired();
			builder.Property(p => p.DriverLicenseId).IsRequired();
		}
	}
}
