using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configuration
{
	public class ClientTypeConfig : IEntityTypeConfiguration<ClientType>
	{
		public void Configure(EntityTypeBuilder<ClientType> builder)
		{
			builder.Property(ct => ct.ClientTypeId)
					.HasConversion<long>();
			builder.HasKey(ct => ct.ClientTypeId);
		}
	}
}
