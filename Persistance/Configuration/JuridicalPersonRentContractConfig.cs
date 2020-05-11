using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configuration
{
	public class JuridicalPersonRentContractConfig : IEntityTypeConfiguration<JuridicalPersonRentContract>
	{
		public void Configure(EntityTypeBuilder<JuridicalPersonRentContract> builder)
		{
			builder.Property(p => p.CompanyAddress).IsRequired();
			builder.Property(p => p.UpperHouseExtractIdentifier).IsRequired();
			builder.Property(p => p.AdministrationPassportIdentifier).IsRequired();
			builder.Property(p => p.DriverLicenseIdentifier).IsRequired();
			builder.Property(p => p.GeneralManagerSignatureIdentifier).IsRequired();
		}
	}
}
