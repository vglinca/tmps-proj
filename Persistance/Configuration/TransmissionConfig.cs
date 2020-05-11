using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configuration
{
	public class TransmissionConfig : IEntityTypeConfiguration<Transmission>
	{
		public void Configure(EntityTypeBuilder<Transmission> builder)
		{
			builder.Property(t => t.TransmissionTypeId)
					.HasConversion<long>();
			builder.HasKey(t => t.TransmissionTypeId);
		}
	}
}
