using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configuration
{
	public class ForeignerRentContractConfig : IEntityTypeConfiguration<ForeignerRentContract>
	{
		public void Configure(EntityTypeBuilder<ForeignerRentContract> builder)
		{
			builder.Property(p => p.InternationalDriverLicenseId).IsRequired();
			builder.Property(p => p.PassportIdentifier).IsRequired();
			builder.Property(p => p.VisaIdentifier).IsRequired();
			builder.Property(p => p.MigrationNumber).IsRequired();
		}
	}
}
