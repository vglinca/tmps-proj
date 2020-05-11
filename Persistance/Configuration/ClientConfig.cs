using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Configuration
{
	public class ClientConfig : IEntityTypeConfiguration<Client>
	{
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.HasOne(c => c.ClientType)
					.WithMany(t => t.Clients)
					.HasForeignKey(c => c.ClientTypeId)
					.OnDelete(DeleteBehavior.Cascade);
			builder.HasMany(c => c.RentContracts)
					.WithOne(r => r.Client)
					.HasForeignKey(c => c.ClientId)
					.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
