using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configuration
{
	public class RentContractConfig : IEntityTypeConfiguration<RentContract>
	{
		public void Configure(EntityTypeBuilder<RentContract> builder)
		{
			builder.Property(p => p.Iban).IsRequired();
		}
	}
}
